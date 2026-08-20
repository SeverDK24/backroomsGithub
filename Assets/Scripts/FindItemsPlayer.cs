using UnityEngine;

public class FindItemsPlayer : MonoBehaviour
{
   public float distance = 10f;
    public Animator anm;
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
                Debug.Log("door detected");
                if (Input.GetKey(KeyCode.E))
                {
                    anm.SetTrigger("open");
                }
            }

        }
        Debug.DrawRay(transform.position, transform.forward * distance, Color.yellow);

    }
}
