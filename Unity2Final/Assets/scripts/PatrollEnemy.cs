using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollEnemy : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoint;
    bool arrived;
    bool patrolling;
    int destination;
    public Transform eye;
    public Transform target;
    Vector3 lastPosition;
    public float viewDis = 10.0f;
    public float viewAngle = 90.0f;
    public LayerMask playerMask;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        patrolling = true;
        lastPosition= transform.position;
    }

    bool CanSeePlayer()
    {
        if(Vector3.Distance(eye.position, target.position) < viewDis)
        {
            Vector3 playerDir = (target.position - eye.position).normalized;
            float angleDifference = Vector3.Angle(eye.forward, playerDir);
            if(angleDifference<viewAngle/2)
            {
                if(!Physics.Linecast(eye.position,target.position, ~playerMask))
                {
                    lastPosition = target.position;
                    return true;
                }
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.pathPending)
        {
            return;
        }
        if(patrolling)
        {
            if(agent.remainingDistance<agent.stoppingDistance)
            {
                if(!arrived)
                {
                    arrived = true;
                    StartCoroutine(GoToNextPatrolPoint());
                }
            }
        }
        else
        {
            arrived= false;
        }
        if(CanSeePlayer())
        {
            agent.SetDestination(target.position);
            patrolling= false;
            //anims go after
            if(agent.remainingDistance<agent.stoppingDistance)
            {
                anim.SetBool("Attack", true);
            }
            else
            {
                anim.SetBool("Attack", false);
            }
        }
        else if(!patrolling)
        {
            anim.SetBool("Attack", false);
            agent.SetDestination(lastPosition);
            if(agent.remainingDistance<agent.stoppingDistance)
            {
                patrolling= true;
                StartCoroutine(GoToNextPatrolPoint());
            }
        }

        anim.SetFloat("Moving", agent.velocity.sqrMagnitude);
    }
    IEnumerator GoToNextPatrolPoint()
    {
        if(waypoint.Length ==0)
        {
            yield break;
        }
        patrolling = true;
        yield return new WaitForSeconds(2.0f);
        arrived= false;
        agent.destination = waypoint[destination].position;
        destination = (destination +1)%waypoint.Length;
    }    
}
