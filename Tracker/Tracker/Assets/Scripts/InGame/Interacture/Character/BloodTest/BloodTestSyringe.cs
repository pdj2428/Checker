using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BloodTestSyringe : MonoBehaviour, IPointerDownHandler
{
    public new AudioClip audio;
    public AudioSource audioSource;
    public Animator bloodTestAnimator;

    public void OnPointerDown(PointerEventData data)
    {
        audioSource.clip = audio;
        audioSource.Play();
        bloodTestAnimator.SetBool("BloodTest", true);
        bloodTestAnimator.SetBool("ChangeSyringe", false);
    }
}
