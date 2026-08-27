using UnityEngine;

public class MonstersSounds : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip[] sounds;

    float timer;

    void Start()
    {
        timer = Random.Range(60f, 120f);
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
