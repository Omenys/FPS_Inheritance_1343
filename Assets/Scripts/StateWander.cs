using UnityEngine;

public class StateWander : State
{
    float stopDistance = 1f;

    public StateWander(StateMachine m) : base(m)
    {

    }

    public override void UpdateState()
    {
        // Debug.Log("I'm wandering");
        float playerDistance = Vector3.Distance(myStateMachine.owner.agent.transform.position, myStateMachine.owner.playerLocation.position);

        // If enemy sees or is near player, switch to pursue
        if (playerDistance <= myStateMachine.owner.playerSightRange)
        {
            myStateMachine.ChangeState(new StatePursue(myStateMachine));
        }

        // If less than stopping distance, switch to idle
        if (myStateMachine.owner.agent.remainingDistance < stopDistance)
        {
            myStateMachine.ChangeState(new StateIdle(myStateMachine));
        }


    }
    public override void EnterState()
    {
        // Debug.Log("Start wandering");

        // Set a random destination at start of state
        myStateMachine.owner.GoToRandomPoint();
    }

    public override void ExitState()
    {
        // Debug.Log("Stop wandering");
    }

}
