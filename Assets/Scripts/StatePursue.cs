using UnityEngine;

public class StatePursue : State
{
    public StatePursue(StateMachine m) : base(m)
    {

    }

    public override void UpdateState()
    {
        Debug.Log("I'm pursuing");

    }
    public override void EnterState()
    {
        Debug.Log("Start pursuing");

    }

    public override void ExitState()
    {
        Debug.Log("Stop pursuing");
    }
}

