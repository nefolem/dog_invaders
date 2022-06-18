using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicSlider : MonoBehaviour
{
    public Slider slider;
    public AudioMixer audioMixer;
    public float oldVolume;
    // Start is called before the first frame update
    void Start()
    {
        oldVolume = slider.value;
        if(!PlayerPrefs.HasKey("music_volume"))
        {
            slider.value = 1;
        }
        else slider.value = PlayerPrefs.GetFloat("music_volume");
    }

    // Update is called once per frame
    void Update()
    {
        if(oldVolume != slider.value)
        {
            PlayerPrefs.SetFloat("music_volume", slider.value);
            PlayerPrefs.Save();
            audioMixer.SetFloat("music", slider.value);
            oldVolume = slider.value;
        }
    }
}

