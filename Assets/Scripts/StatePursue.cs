using UnityEngine;

public class StatePursue : State
{
    float elapsedTime = 0;
    public StatePursue(StateMachine m) : base(m)
    {

    }

    public override void UpdateState()
    {
        Debug.Log("I'm pursuing");
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 6)
        {
            myStateMachine.ChangeState(new StateAttack(myStateMachine));
        }
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

