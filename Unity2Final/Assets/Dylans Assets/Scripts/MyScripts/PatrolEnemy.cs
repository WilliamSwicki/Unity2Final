using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : MonoBehaviour
{

    NavMeshAgent agent;
    public Transform[] waypoints;
    bool arrived;
    bool patrolling;
    int destination;
    public Transform eye;
    public Transform target;
    Vector3 lastPosition;
    [SerializeField] float viewDistance = 10.0f;
    [SerializeField] float viewAngle = 90.0f;
    public LayerMask playerMask;
    public Animator anim;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolling = true;
        lastPosition = transform.position;
    }

    bool CanSeePlayer()
    {

        if(Vector3.Distance(eye.position, target.position) < viewDistance)
        {
            Vector3 playerDir = (target.position - eye.position).normalized;
            float angleDifference = Vector3.Angle(eye.forward, playerDir);

            if(angleDifference < viewAngle/2)
            {
                if(!Physics.Linecast(eye.position, target.position, ~playerMask)) 
                {
                    lastPosition = target.position;
                    return true;   
                }
            }
        }

        return false;

    }

    void Update()
    {


        if(agent.pathPending) 
        {
            return;
        }
        //code for patrolling

        if(patrolling)
        {
            if(agent.remainingDistance < agent.stoppingDistance)
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
            arrived=false;
        }
        //code for when enemy sees target
        if(CanSeePlayer())
        {
            agent.SetDestination(target.position);
            patrolling = false;
            //setup attack

            if(agent.remainingDistance < agent.stoppingDistance)
            {
                anim.SetBool("Attack", true);
            }
            else
            {
                anim.SetBool("Attack", false);
            }

        }
        else
        {
            if(!patrolling)
            {
                anim.SetBool("Attack", false );
                agent.SetDestination(lastPosition);
                if(agent.remainingDistance < agent.stoppingDistance)
                {
                    patrolling = true;
                    StartCoroutine(GoToNextPatrolPoint());
                }
            }
        }
        //play move animation
        anim.SetFloat("Running", agent.velocity.sqrMagnitude);
    }

    IEnumerator GoToNextPatrolPoint()
    {
        if(waypoints.Length == 0)
        {
            yield break;
        }

        patrolling = true;

        yield return new WaitForSeconds(2.0f);

        arrived = false;
        agent.destination = waypoints[destination].position;
        destination = (destination +1) % waypoints.Length; 
    }
}
