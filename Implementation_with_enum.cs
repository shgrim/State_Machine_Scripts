using UnityEngine;
using System.Collections;

public class Statemachine_FSM : MonoBehaviour
{

    public enum State
    {
        Idle,
        Initialize,
        Setup,
        Combat,
        Looting
    }

    public enum Combat
    {
        FindEnemy,
        AttackEnemy,
        EnemyDead
    }

    private State _state; //Local variable that represents our state
    public Combat combat;

    IEnumerator Start()
    {
        _state = State.Initialize;
        combat = Combat.FindEnemy;

        while (true)
        {
            switch (_state)
            {
                case State.Initialize:
                    InitMe();
                    break;
                case State.Setup:
                    SetMeUp();
                    break;
                case State.Combat:
                    InCombat();
                    break;
                case State.Looting:
                    Looting();
                    break;
            }
            yield return 0;
        }
    }

    private void InitMe()
    {
        Debug.Log("This is the InitMe function");
        _state = State.Setup;
    }
    private void SetMeUp()
    {
        Debug.Log("This is the SetMeUp function");
        _state = State.Combat;
    }
    private void InCombat()
    {
        Debug.Log("In Combat");

        switch (combat)
        {
            case Combat.FindEnemy:
                FindEnemy();
                break;
            case Combat.AttackEnemy:
                AttackEnemy();
                break;
            case Combat.EnemyDead:
                EnemyDead();
                break;
        }
    }
    private void Looting()
    {
        Debug.Log("Looting");
        _state = State.Idle;
    }

    private void FindEnemy()
    {
        Debug.Log("Finding Enemy");
        combat = Combat.AttackEnemy;
    }
    private void AttackEnemy()
    {
        Debug.Log("Attacking Enemy");
        combat = Combat.EnemyDead;
    }
    private void EnemyDead()
    {
        Debug.Log("Enemy Dead");
        combat = Combat.FindEnemy;
        _state = State.Looting;
    }
}