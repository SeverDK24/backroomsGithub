using UnityEngine;

public class OpenWalls : MonoBehaviour
{
    public GameObject wall;
    public GameObject wall1;
    public GameObject wall2;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Open()
    {
        Debug.Log(wall);
        Debug.Log(wall1);
        Debug.Log(wall2);

        wall.SetActive(false);
        wall1.SetActive(false);
        wall2.SetActive(false);
    }
}
