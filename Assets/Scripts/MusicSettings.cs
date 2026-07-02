using UnityEngine;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    public Butons butons;
    public AudioSource music;
   // public Slider musicSlider;

    void Start()
    {
       

        butons.musicslider.value = music.volume;
        butons.musicslider.onValueChanged.AddListener(ChangeVolume);
    }

    public void ChangeVolume(float value)
    {
        Debug.Log(value);
       
        music.volume = value;
    }


}
