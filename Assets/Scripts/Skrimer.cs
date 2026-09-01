using UnityEngine;

public class Skrimer : MonoBehaviour
{
    public GameObject[] screamersPhotos;

    private float timer = 0f;
    private float nextScreamerTime;

    void Start()
    {
        nextScreamerTime = Random.Range(30f, 60f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextScreamerTime)
        {
            ShowScreamer();

            timer = 0f;
            nextScreamerTime = Random.Range(30f, 60f);
        }
    }

    void ShowScreamer()
    {
        int randomIndex = Random.Range(0, screamersPhotos.Length);

        GameObject screamer = screamersPhotos[randomIndex];

        screamer.SetActive(true);

        Animator animator = screamer.GetComponent<Animator>();
        animator.Play("Screamer", 0, 0f);
    }
}
