using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    //public AudioSource audioSource;
    public AudioMixer audioMixer;

    // Update is called once per frame
    void Update()
    {
        audioMixer.SetFloat("music", PlayerPrefs.GetFloat("music_volume"));
        audioMixer.SetFloat("sound", PlayerPrefs.GetFloat("sound_volume"));
        //audioSource.volume = PlayerPrefs.GetFloat("value");
    }

    // public void SetSoundVolume()
    // {
    //     audioMixer.SetFloat("sound", 1);

    // }
}
