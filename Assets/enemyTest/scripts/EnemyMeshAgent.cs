using UnityEngine;
using UnityEngine.AI;

public class EnemyMeshAgent : EnemyBehave
{
    private NavMeshAgent agent;
    public Transform pos;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

   
    void Update()
    {
        agent.SetDestination(pos.position); 
    }
    public void SetPosition()
    {
        agent.SetDestination(playerpos.position);       
    }
    private void OnCollisionEnter(Collision collision)
    {
      //  if (collision.ga) я його закомітила бо воно видавало помилку і не давало мені запустити гру :)
    }
}
