using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalCheck : MonoBehaviour
{

    public new AudioClip audio;
    public AudioSource audioSource;

    public Animator vitalCheckAnimator;
    public void Activation()
    {
        audioSource.clip = audio;
        audioSource.Play();

        if (vitalCheckAnimator.GetBool("UnCheck"))
        {
            vitalCheckAnimator.SetBool("Check", true);
            vitalCheckAnimator.SetBool("UnCheck", false);
        }
        else if (vitalCheckAnimator.GetBool("UnCheck") == false)
        {
            vitalCheckAnimator.SetBool("Check", false);
            vitalCheckAnimator.SetBool("UnCheck", true);
        }
    }
}
