using UnityEngine;

public class StatePursue : State
{
    public StatePursue(StateMachine m) : base(m)
    {

    }

    public override void UpdateState()
    {
        // Debug.Log("I'm pursuing");

        float playerDistance = Vector3.Distance(myStateMachine.owner.agent.transform.position, myStateMachine.owner.playerLocation.position);
        myStateMachine.owner.agent.SetDestination(myStateMachine.owner.playerLocation.position);

        // If player is within attack range, switch to attack state
        if (playerDistance <= myStateMachine.owner.playerAttackRange)
        {
            myStateMachine.ChangeState(new StateAttack(myStateMachine));
        }
        // If player distance is outside of enemy vision, switch back to wander
        if (playerDistance > myStateMachine.owner.playerSightRange)
        {
            myStateMachine.ChangeState(new StateWander(myStateMachine));
        }
    }
    public override void EnterState()
    {
        // Debug.Log("Start pursuing");

    }

    public override void ExitState()
    {
        // Debug.Log("Stop pursuing");
    }
}

