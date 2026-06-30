using UnityEngine;
using UnityEngine.AI;

public class EnemyMeshAgent : EnemyBehave
{
    private NavMeshAgent agent;
    //public Transform pos; 
    private bool isTouched = false;
    public Transform[] points;
    private int whatpoint;  
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        whatpoint = Random.Range(0, 6);
        transform.LookAt(points[whatpoint].position);
        agent.SetDestination(points[whatpoint].position);
    }

   
    void Update()
    {
       // agent.SetDestination(pos.position); 
       if (isTouched)
        {

        }
    }
    public void SetPosition()
    {
        agent.SetDestination(playerpos.position);       
    }
    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.tag == "point")
        {
            
                isTouched = true;
                whatpoint = Random.Range(0, 6);
                Debug.Log(whatpoint);
                transform.LookAt(points[whatpoint].position);
                agent.SetDestination(points[whatpoint].position);
            
            

        }
    }
}
