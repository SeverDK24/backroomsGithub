using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PatrolAI : MonoBehaviour
{
    public PatrolPoint[] patrolPoints;
    public Transform playerpos;
    private NavMeshAgent agent;
    private PatrolPoint currentPoint;
    public float viewDistance = 10f;
    public float viewAngle = 60f;
    public Transform player;
    private float rad = 3f;
    public float detectionRadius = 10f;

    private bool chasingPlayer = false;
    
   

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToRandomPoint();
    }

    private void Update()
    {


        CheckPlayer();

        if (chasingPlayer)
        {
            transform.LookAt(player);
            agent.SetDestination(player.position);
            return;
        }


        Collider[] hits = Physics.OverlapSphere(
            currentPoint.transform.position,
            currentPoint.radius);

        foreach (Collider hit in hits)
        {
            //if (hit.gameObject.tag == "player")
            //{
            //    Debug.Log("player spotted");
            //    agent.SetDestination(playerpos.position);
            //    transform.LookAt(playerpos.position);

            //}
            if (hit.transform == transform)
            {
                GoToRandomPoint();
                transform.LookAt(hit.transform.position);
                break;
            }
           
        }
    }

    private void GoToRandomPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        int index;

        do
        {
            index = Random.Range(0, patrolPoints.Length);
        }
        while (patrolPoints.Length > 1 && patrolPoints[index] == currentPoint);

        currentPoint = patrolPoints[index];
        agent.SetDestination(currentPoint.transform.position);
    }
    void CheckPlayer()
    {
        Collider[] objects = Physics.OverlapSphere(
            transform.position,
            detectionRadius
        );

        bool playerFound = false;

        foreach (Collider obj in objects)
        {
            if (obj.CompareTag("player"))
            {
                player = obj.transform;
                playerFound = true;
                chasingPlayer = true;
                break;
            }
        }

        if (!playerFound && chasingPlayer)
        {
            chasingPlayer = false;
            player = null;

            GoToRandomPoint();
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (currentPoint == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rad);
    }
}