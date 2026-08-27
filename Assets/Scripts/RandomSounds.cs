using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sounds;

    float timer;

    void Start()
    {
        timer = Random.Range(30f, 60f);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            int randomSound = Random.Range(0, sounds.Length);
            audioSource.PlayOneShot(sounds[randomSound]);

            timer = Random.Range(60f, 120f);
        }
    }
}
