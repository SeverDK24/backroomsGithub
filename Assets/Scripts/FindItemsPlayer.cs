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
            if (hit.collider.gameObject.tag == "door")
            {
                Debug.Log("open");
            }

        }
        Debug.DrawRay(transform.position, transform.forward * distance, Color.yellow);

    }
}
