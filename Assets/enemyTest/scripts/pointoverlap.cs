using UnityEngine;

public class pointoverlap : MonoBehaviour
{
    private float rad = 0.5f;
    public bool isSpot = false;
    //public EnemyMeshAgent em;
    void Start()
    {
        
    }

  
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, rad);
        foreach (Collider hit in hits)
        {
            if (hit.gameObject.tag == "monster")
            {
                isSpot = true;  
               

            }
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rad);
    }
}
