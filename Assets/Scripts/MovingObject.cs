using UnityEngine;
using UnityEngine.AI;

public class MovingObject : MonoBehaviour
{
    public StateMachine myStateMachine;
    public NavMeshAgent agent;
    public Transform playerLocation;

    public float wanderRange = 2.0f;
    public Vector3 startingLocation;
    public float playerSightRange = 10.0f;
    public float playerAttackRange = 2.0f;
    public float currentStateElapsed = 0f;
    public float recoveryTime = 2f;



    // Start is called before the first frame update
    void Start()
    {
        myStateMachine = new StateMachine();
        myStateMachine.Initialize(this, new StateIdle(myStateMachine));
        agent = GetComponent<NavMeshAgent>();
        startingLocation = transform.position;

        GetRandomPointInRange();
    }

    // Update is called once per frame
    void Update()
    {
        myStateMachine.Update();
    }

    public void GoToRandomPoint()
    {
        agent.SetDestination(GetRandomPointInRange());
    }

    Vector3 GetRandomPointInRange()
    {
        Vector3 offset = new Vector3(Random.Range(-wanderRange, wanderRange),
            0,
            Random.Range(-wanderRange, wanderRange));

        NavMeshHit hit;

        bool gotPoint = NavMesh.SamplePosition(startingLocation + offset, out hit, 1, NavMesh.AllAreas);

        if (gotPoint)
        {
            return hit.position;
        }
        return Vector3.zero;
    }
}
