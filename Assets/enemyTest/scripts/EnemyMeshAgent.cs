using UnityEngine;
using UnityEngine.AI;

public class EnemyMeshAgent : MonoBehaviour
{
    private NavMeshAgent agent;
    //public Transform pos; 
    
    public Transform[] points;
    private int whatpoint;
    public pointoverlap po;
    public EnemyBehave pp;
    private float time = 3;
    private float timer;
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
      
       
    }
    public void SetPosition()
    {
        agent.SetDestination(pp.playerpos.position);
    }
    private void OnReachPoint()
    {
        if (po.isSpot)
        {
            Debug.Log(po.isSpot);       
            timer = Time.deltaTime;
            if (time <= timer)
            {
                po.isSpot = false;
                whatpoint = Random.Range(0, 6);
                time = 3;

            }



           
            Debug.Log(whatpoint);
            transform.LookAt(points[whatpoint].position);
            agent.SetDestination(points[whatpoint].position);
        }

    }

    
}
