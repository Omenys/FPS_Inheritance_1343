public class StateMachine
{
    State currentState;
    public MovingObject owner; // getter and setter would be better

    public void Initialize(MovingObject mo, State initialState)
    {
        owner = mo;
        ChangeState(initialState);
    }

    public void ChangeState(State newState)
    {
        //currentState?.ExitState();
        currentState = newState;
        currentState.EnterState();
    }

    // Update is called once per frame
    public void Update()
    {
        currentState?.UpdateState();
    }
}

public class State
{
    protected StateMachine myStateMachine;

    public State(StateMachine m)
    {
        myStateMachine = m;
    }

    public virtual void UpdateState()
    {

    }
    public virtual void EnterState()
    {

    }

    public virtual void ExitState()
    {

    }

}
