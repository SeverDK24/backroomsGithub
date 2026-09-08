using UnityEngine;

public class EnemyBehave : MonoBehaviour
{
    public float rad = 5f;
    public Transform playerpos;
    public Animator anim;
    public EnemyMeshAgent ma;
    protected bool isspotted = false;   
    void Start()
    {
        
    }


    void Update()
    {
      

        Collider[] hits = Physics.OverlapSphere(transform.position, rad);
        foreach (Collider hit in hits)
        {
            if (hit.gameObject.tag == "player")
            {
                isspotted = true;
                Debug.Log("player spotted");
                ma.SetPosition();

            }

            if (hit.gameObject.tag == null)
            {
                
            }
        }


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green; 
        Gizmos.DrawWireSphere(transform.position, rad); 
    }
}
