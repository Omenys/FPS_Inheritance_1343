using UnityEngine;

public class StateAttack : State
{
    float elapsedTime = 0;
    public StateAttack(StateMachine m) : base(m)
    {

    }

    public override void UpdateState()
    {
        Debug.Log("I'm attacking");
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 8)
        {
            myStateMachine.ChangeState(new StateIdle(myStateMachine));
        }
    }
    public override void EnterState()
    {
        Debug.Log("Start attacking");
    }

    public override void ExitState()
    {
        Debug.Log("Stop attacking");
    }
}

