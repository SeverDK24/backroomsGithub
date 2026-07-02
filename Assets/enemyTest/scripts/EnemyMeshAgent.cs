using UnityEngine;
using UnityEngine.AI;

public class EnemyMeshAgent : MonoBehaviour
{
    private NavMeshAgent agent;
    //public Transform pos; 
    private bool isTouched = false;
    public Transform[] points;
    private int whatpoint;
    public pointoverlap po;
    public EnemyBehave pp;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        whatpoint = Random.Range(0, 6);
        transform.LookAt(points[whatpoint].position);
        agent.SetDestination(points[whatpoint].position);
    }

   
    void Update()
    {
        OnReachPoint();
       // agent.SetDestination(pos.position); 
       if (isTouched)
        {

        }
    }
    public void SetPosition()
    {
        agent.SetDestination(pp.playerpos.position);
    }
    private void OnReachPoint()
    {
        if (po.isSpot)
        {
            po.isSpot = false;

            isTouched = true;
            whatpoint = Random.Range(0, 6);
            Debug.Log(whatpoint);
            transform.LookAt(points[whatpoint].position);
            agent.SetDestination(points[whatpoint].position);
        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //  if (collision.gameObject.tag == "point")
    //    {

    //            isTouched = true;
    //            whatpoint = Random.Range(0, 6);
    //            Debug.Log(whatpoint);
    //            transform.LookAt(points[whatpoint].position);
    //            agent.SetDestination(points[whatpoint].position);



    //    }
    //}
}
