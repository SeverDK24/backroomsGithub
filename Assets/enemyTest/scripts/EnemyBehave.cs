using UnityEngine;

public class EnemyBehave : MonoBehaviour
{
    public float rad = 5f;
    public Transform playerpos;
    public Animator anim;
    public EnemyMeshAgent ma;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.LookAt(playerpos);
        Collider[] hits = Physics.OverlapSphere(transform.position, rad);
            foreach (Collider hit in hits)
        {
            if (hit.gameObject.tag == "player")
            {
                Debug.Log("player spotted");
                ma.SetPosition();
                
            }
            //if (hits == null)
            //{
            //    anim.SetTrigger("islost");
            //}
        }


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green; 
        Gizmos.DrawWireSphere(transform.position, rad); 
    }
}
