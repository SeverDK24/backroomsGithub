using System.Runtime.CompilerServices;
using UnityEngine;

public class FindItemsPlayer : MonoBehaviour
{
    public float distance = 10f;
    public Animator anm;
    public Animator anm1;
    private bool iskey = false;

    public OpenWalls openWalls;//силка на мій скрпит 
   
    void Start()
    {

    }


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
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

        //Для ричага
            if (hit.collider.CompareTag("lever"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Було нажато");
                    hit.collider.GetComponentInParent<Animator>().SetTrigger("Press lever");
                    openWalls.Open();
                   
                }
            }

        }
        Debug.DrawRay(transform.position, transform.forward * distance, Color.yellow);

        

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * distance);
    }
}
