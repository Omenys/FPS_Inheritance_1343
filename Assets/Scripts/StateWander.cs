using UnityEngine;

public class StateWander : State
{
    float elapsedTime = 0;
    public StateWander(StateMachine m) : base(m)
    {

    }

    public override void UpdateState()
    {
        Debug.Log("I'm wandering");
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 4)
        {
            myStateMachine.ChangeState(new StatePursue(myStateMachine));
        }
    }
    public override void EnterState()
    {
        Debug.Log("Start wandering");
    }

    public override void ExitState()
    {
        Debug.Log("Stop wandering");
    }
}
