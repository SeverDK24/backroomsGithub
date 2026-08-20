using UnityEngine;

public class FindItemsPlayer : MonoBehaviour
{
   public float distance = 10f;
    public Animator anm;
    public Animator anm1;
    private bool iskey = false; 
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
                    if (hit.collider.gameObject.name == "Door")
                    {
                        anm.SetTrigger("open");
                    }

                    if (hit.collider.gameObject.name == "Door1")
                    {
                        Debug.Log("key needed");
                        if (iskey)
                        {
                            anm1.SetTrigger("open");    
                        }
                    }

                }
            }
            if (hit.collider.gameObject.tag == "key")
            {
                Debug.Log("натисніть ліву кнопку миші щоб підібрати");
                iskey = true;   
            }


        }
        Debug.DrawRay(transform.position, transform.forward * distance, Color.yellow);

    }
}
