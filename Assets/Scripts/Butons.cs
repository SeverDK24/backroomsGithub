using UnityEngine;
using UnityEngine.SceneManagement;

public class Butons : MonoBehaviour
{

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
}
