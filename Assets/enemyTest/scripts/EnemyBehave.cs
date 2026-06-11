using UnityEngine;

public class EnemyBehave : MonoBehaviour
{
    public float rad = 5f;
    public Transform playerpos;
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
                Debug.Log("player spotted");
            }
        }


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green; 
        Gizmos.DrawWireSphere(transform.position, rad); 
    }
}
