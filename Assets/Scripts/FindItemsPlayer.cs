using System.Runtime.CompilerServices;
using UnityEngine;

public class FindItemsPlayer : MonoBehaviour
{
   public float distance = 10f;
    void Start()
    {
        
    }

    
    void Update()
    {
        RaycastHit hit; 
        if (Physics.Raycast(transform.position, transform.forward, out hit,distance))
        {
          if (hit.collider.gameObject.tag == "test")
            {
                Debug.Log("contact");
            }

        }
        Debug.DrawRay(transform.position, transform.forward * distance, Color.yellow);

        //Для ричага
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (hit.collider.CompareTag("lever"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Було нажато");
                    hit.collider.GetComponentInParent<Animator>().SetTrigger("Press lever");
                }
            }
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * distance);
    }
}
