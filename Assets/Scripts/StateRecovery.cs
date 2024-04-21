using UnityEngine;

public class StateRecovery : State
{
    float timeInRecovery = 0f;
    public StateRecovery(StateMachine m) : base(m)
    {

    }

    public override void UpdateState()
    {
        //Debug.Log("I'm recovering");

        // Update recovery timer
        timeInRecovery += Time.deltaTime;

        // If recovery time is met, go back to pursue state
        if (timeInRecovery >= myStateMachine.owner.recoveryTime)
        {
            myStateMachine.ChangeState(new StatePursue(myStateMachine));
        }


    }
    public override void EnterState()
    {
        //Debug.Log("Start recovering");

        // Reset recovery timer
        timeInRecovery = 0;
    }

    public override void ExitState()
    {
        //Debug.Log("Stop recovering");
    }

}
