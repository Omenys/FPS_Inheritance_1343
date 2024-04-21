using UnityEngine;

public class StateAttack : State
{
    Vector3 attackDirection;
    float attackForce = 20f;


    public StateAttack(StateMachine m) : base(m)
    {

    }

    public override void UpdateState()
    {
        //Debug.Log("I'm attacking!");

        // Get distance to player
        float distanceToPlayer = Vector3.Distance(myStateMachine.owner.transform.position, myStateMachine.owner.playerLocation.position);

        // If player not in attack range, pursue
        if (distanceToPlayer > myStateMachine.owner.playerAttackRange)
        {
            myStateMachine.ChangeState(new StatePursue(myStateMachine));
        }

    }

    public override void EnterState()
    {
        //Debug.Log("Start attacking");

        // Get direction towards the player 
        attackDirection = (myStateMachine.owner.playerLocation.position - myStateMachine.owner.transform.position).normalized;

        // Get rigidbody and adjust physics
        Rigidbody rb = myStateMachine.owner.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        myStateMachine.owner.agent.enabled = false;

        // Attack force
        rb.AddForce(attackDirection * attackForce, ForceMode.Impulse);

    }


    public override void ExitState()
    {
        //Debug.Log("Stop attacking");

        // Turn kinematic on
        myStateMachine.owner.GetComponent<Rigidbody>().isKinematic = true;

        // Turn NavMesh on
        myStateMachine.owner.agent.enabled = true;

    }
}



