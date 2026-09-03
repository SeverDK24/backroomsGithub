using UnityEngine;

public class Skrimer : MonoBehaviour
{
    public GameObject[] screamersPhotos;
    public AudioClip[] screamersSounds;
    public AudioSource audioSource;

    private float timer = 0f;
    private float nextScreamerTime;
    private GameObject currentScreamer;
    private float screamerTimer = 0f;


    void Start()
    {
        nextScreamerTime = Random.Range(30f, 60f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Время для появления скримера
        if (timer >= nextScreamerTime)
        {
            ShowScreamer();

            timer = 0f;
            nextScreamerTime = Random.Range(30f, 60f);
        }

        // Таймер самого скримера
        if (currentScreamer != null)
        {
            screamerTimer += Time.deltaTime;

            if (screamerTimer >= 0.23f)
            {
                currentScreamer.SetActive(false);
                currentScreamer = null;
            }
        }
    }

    void ShowScreamer()
    {
        int randomIndex = Random.Range(0, screamersPhotos.Length);

        currentScreamer = screamersPhotos[randomIndex];

        currentScreamer.SetActive(true);

        Animator animator = currentScreamer.GetComponent<Animator>();
        animator.Rebind();
        animator.Update(0f);

        screamerTimer = 0f;

        audioSource.PlayOneShot(screamersSounds[randomIndex]);

        Debug.Log("Skrimer");
    }
}
