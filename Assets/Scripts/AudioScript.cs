using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip hoverFx;
    public AudioClip clickFx;
    public AudioClip warningFx;
    public AudioClip bossFightFX;

    private bool isWarnPlaying, isBossFightPlaying = false;



    public void HoverSound()
    {
        myFX.PlayOneShot(hoverFx);
    }

    public void ClickSound()
    {
        myFX.PlayOneShot(clickFx);
    }

    public void WarningSound()
    {
        if (!isWarnPlaying)
        {
            myFX.PlayOneShot(warningFx);
            isWarnPlaying = true;
        }

    }
    public void BossFightSound(bool play)
    {
        if (play)
        {
            if (!isBossFightPlaying)
            {
                myFX.Play();
                isBossFightPlaying = true;
            }
        }
        else if (!play)
        {
            myFX.Stop();
        }

    }

}
