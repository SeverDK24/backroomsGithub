using UnityEngine;

public class Pouse : MonoBehaviour
{
    public ControlCameraByMouse controlCameraByMouse;

    private bool isPaused = false;

    public GameObject image;
    public GameObject image1;
    public GameObject textpoused;
    public GameObject butonsetting;
    public GameObject butonexittomenue;

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
        controlCameraByMouse.canLook = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
        isPaused = true;
        image.SetActive(true);
        image1.SetActive(true);
        butonsetting.SetActive(true);
        textpoused.SetActive(true);
        butonexittomenue.SetActive(true);
        Debug.Log("Пауза!");
    }
    void ResumeGame()
    {
        controlCameraByMouse.canLook = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;
        isPaused = false;
        image.SetActive(false);
        image1.SetActive(false);
        butonsetting.SetActive(false);
        textpoused.SetActive(false);
        butonexittomenue.SetActive(false);
        Debug.Log("Нема паузи");
    }
}
