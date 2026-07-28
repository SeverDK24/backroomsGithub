using Unity.VisualScripting;
using UnityEngine;

public class PlayerHearts : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public Vector3 CubSize;
    public Vector3 CubPosition;

    public float timer = 2;
    public int lives = 3;                // серця
    float cooldown = 2f;          // таймер паузи
    void Start()
    {

    }


    void Update()
    {
        
        EnemyDamage();
    }

    public void EnemyDamage()
    {
        if (cooldown >= 0)
            cooldown -= Time.deltaTime;

        Vector3 center = transform.position + CubPosition;
        Collider[] hits = Physics.OverlapBox(center, CubSize, Quaternion.identity);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("monster") && cooldown <= 0)
            {
                LoseHearts();
                cooldown = 2f; // пауза 2 секунди
               
            }
        }
    }
    public void LoseHearts()
    {
        lives -= 1;
        //if (lives == 3)
        //{
        //    heart3.SetActive(false);
        //}
        if (lives == 2)
        {
            heart3.SetActive(false);
        }
        if (lives == 1)
        {
            heart2.SetActive(false);

        }


        
        if (lives <= 0)
        {
            lives = 0;
            heart2.SetActive(false);
            Debug.Log("PlayerDied");
            
        }
           
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
        Gizmos.DrawCube(transform.position + CubPosition, CubSize);
    }
}
