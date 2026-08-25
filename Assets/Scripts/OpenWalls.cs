using UnityEngine;

public class OpenWalls : MonoBehaviour
{
    public GameObject wall;
    public GameObject wall1;
    public GameObject wall2;
    public AudioSource WallsSound;

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

        WallsSound.Play();
    }
}
