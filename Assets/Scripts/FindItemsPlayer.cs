using System.Runtime.CompilerServices;
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

                    if (hit.collider.gameObject.tag == "Door1")
                    {
                        Debug.Log("key needed");
                        if (Input.GetKeyDown(KeyCode.E) && iskey) 
                        {
                            anm1.SetTrigger("open");    
                        }
                    }
                    if (hit.collider.gameObject.tag == "lever")
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            Debug.Log("Ѕуло нажато");
                            hit.collider.GetComponentInParent<Animator>().SetTrigger("Press lever");
                        }
                    }

                }
            }
            if (hit.collider.gameObject.tag == "key")
            {
                Debug.Log("натисн≥ть л≥ву кнопку миш≥ щоб п≥д≥брати");
                if (Input.GetMouseButtonDown(0))
                {
                    iskey = true;
                    Debug.Log(iskey);
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
