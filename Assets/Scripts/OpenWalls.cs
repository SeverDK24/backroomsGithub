using UnityEngine;

public class OpenWalls : MonoBehaviour
{
    public GameObject wall;
    public GameObject wall1;
    public GameObject wall2;
    public AudioSource WallsSound;
    public bool leverdown = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Open()
    {
        
        wall.SetActive(false);
        wall1.SetActive(false);
        wall2.SetActive(false);

        if (leverdown == false)
        {
            WallsSound.Play();
            leverdown = true;
        }
    }
}
