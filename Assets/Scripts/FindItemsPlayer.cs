using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class FindItemsPlayer : MonoBehaviour
{
    public float distance = 10f;
    public Animator anm;
    public Animator anm1;
    public Animator anm2;
    private bool iskey = false;
    private bool iskey2 = false;
    private bool isham = false;
    public GameObject key1;
    public GameObject key2;
    public GameObject hamm;
    public OpenWalls openWalls;//силка на мій скрпит 
    public GameObject[] planks;
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
            if (hit.collider.gameObject.tag == "Door1")
            {
                Debug.Log("key needed");
                if (Input.GetKey(KeyCode.E) && iskey)
                {
                    anm1.SetTrigger("open");
                }
            }
            if (hit.collider.gameObject.tag == "Door2")
            {
                Debug.Log("key needed");
                if (Input.GetKey(KeyCode.E) && iskey2)
                {
                    anm2.SetTrigger("open");
                }
            }
            if (hit.collider.gameObject.tag == "door")
            {
               
                if (Input.GetKey(KeyCode.E))
                {
                    if (hit.collider.gameObject.name == "Door")
                    {
                        anm.SetTrigger("open");
                    }

                    

                }
                
            }
            if (hit.collider.gameObject.tag == "key") 
            {
                if (Input.GetMouseButtonDown(0))
                {

                    Debug.Log("натисніть ліву кнопку миші щоб підібрати");
                    iskey = true;
                    key1.SetActive(false);
                }







            }
            if (hit.collider.gameObject.tag == "key2")
            {
                if (Input.GetMouseButtonDown(0))
                {

                    Debug.Log("натисніть ліву кнопку миші щоб підібрати");
                    iskey2 = true;
                    key2.SetActive(false);
                }
            }
            if (hit.collider.gameObject.tag == "hammer")
            {
                if (Input.GetMouseButtonDown(0))
                {

                    Debug.Log("натисніть ліву кнопку миші щоб підібрати");
                    isham = true;
                    hamm.SetActive(false);
                }
            }
            if (hit.collider.gameObject.tag == "plank")
            {
                if (isham)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        planks[1].SetActive(false);
                        planks[2].SetActive(false);
                        planks[3].SetActive(false);
                        planks[0].SetActive(false);
                    }

                }
            }
            if (hit.collider.gameObject.tag == "plank1")
            {
                if (isham)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        planks[4].SetActive(false);
                        planks[5].SetActive(false);
                        planks[6].SetActive(false);
                        planks[7].SetActive(false);
                    }

                }
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
