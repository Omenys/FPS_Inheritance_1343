using UnityEngine;

public class MovingObject : MonoBehaviour
{
    StateMachine myStateMachine;

    // Start is called before the first frame update
    void Start()
    {
        myStateMachine = new StateMachine();
        myStateMachine.Initialize(new StateIdle(myStateMachine));
    }

    // Update is called once per frame
    void Update()
    {
        myStateMachine.Update();
    }
}
