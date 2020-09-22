using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XRayCheck : MonoBehaviour
{
    public new AudioClip audio;
    public AudioSource audioSource;

    public Animator xRayAnimator;
    public Button button;
    public void Check()
    {
        audioSource.clip = audio;
        audioSource.Play();

        button.interactable = true;
        xRayAnimator.SetBool("Check", true);
        xRayAnimator.SetBool("Activation", false);
    }
}
