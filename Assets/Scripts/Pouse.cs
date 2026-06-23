using UnityEngine;

public class Pouse : MonoBehaviour
{
    private bool isPaused = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            
            else
                PauseGameFunc();


            

        }
    }


    void PauseGameFunc()
    {
        Time.timeScale = 0f;
        isPaused = true;
        Debug.Log("Пауза!");
    }
    void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log("Нема паузи");
    }
}
