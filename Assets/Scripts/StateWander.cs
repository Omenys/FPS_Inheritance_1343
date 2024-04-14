using UnityEngine;

public class StateWander : State
{
    float stopDistance = 0.5f;
    public StateWander(StateMachine m) : base(m)
    {

    }

    public override void UpdateState()
    {
        Debug.Log("I'm wandering");

        if (myStateMachine.owner.agent.remainingDistance < stopDistance)
        {
            myStateMachine.ChangeState(new StateIdle(myStateMachine));
        }

    }
    public override void EnterState()
    {
        Debug.Log("Start wandering");

        // Set a random destination at start of state
        myStateMachine.owner.GoToRandomPoint();
    }

    public override void ExitState()
    {
        Debug.Log("Stop wandering");
    }

}
