using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Butons : MonoBehaviour
{
    public GameObject image;
    public GameObject buton;
    public Slider musicslider;

    void Start()
    {

    }


    void Update()
    {

    }
    public void StartGame()
    {
        ChangeScene(1);
    }

    public void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("You left the game");
    }
    public void ExitToMenu()
    {
        ChangeScene(0);
    }

    public void OpenSettings()
    {
        musicslider.gameObject.SetActive(true);
        image.SetActive(true);
        buton.SetActive(true);
    }

    public void CloseSetting()
    {
        musicslider.gameObject.SetActive(false);
        image.SetActive(false);
        buton.SetActive(false);
    }
}
