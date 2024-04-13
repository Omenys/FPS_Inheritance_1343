using UnityEngine;

public class StateIdle : State
{
    float elapsedTime = 0;
    public StateIdle(StateMachine m) : base(m)
    {

    }

    public override void UpdateState()
    {
        Debug.Log("I'm idle!");
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 2)
        {
            myStateMachine.ChangeState(new StateWander(myStateMachine));
        }
    }
    public override void EnterState()
    {
        Debug.Log("Start idle");
    }

    public override void ExitState()
    {
        Debug.Log("Stop idle");
    }
}
