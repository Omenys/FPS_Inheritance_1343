using UnityEngine;

public class StateAttack : State
{
    public StateAttack(StateMachine m) : base(m)
    {

    }

    public override void UpdateState()
    {
        Debug.Log("I'm attacking");

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

