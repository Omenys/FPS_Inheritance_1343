using UnityEngine;

public class StateIdle : State
{

    public StateIdle(StateMachine m) : base(m)
    {
    }

    public override void UpdateState()
    {
        Debug.Log("I'm idle!");

        // Update time 
        myStateMachine.owner.currentStateElapsed += Time.deltaTime;

        // If the time has been longer than the recovery time, switch to wander
        if (myStateMachine.owner.currentStateElapsed >= myStateMachine.owner.recoveryTime)
        {
            myStateMachine.ChangeState(new StateWander(myStateMachine));
        }
    }
    public override void EnterState()
    {
        Debug.Log("Start idle");

        // Reset idle timer
        myStateMachine.owner.currentStateElapsed = 0;
    }

    public override void ExitState()
    {
        Debug.Log("Stop idle");
    }
}
