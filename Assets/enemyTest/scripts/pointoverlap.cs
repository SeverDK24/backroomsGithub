using UnityEngine;

public class pointoverlap : MonoBehaviour
{
    private float rad = 0.5f;
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
                ma.SetPosition();

            }
            //if (hits == null)
            //{
            //    anim.SetTrigger("islost");
            //}
        }
    }
}
