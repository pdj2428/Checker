using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BloodTestTableSD : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public new AudioClip audio;
    public AudioSource audioSource;

    public Animator bloodTestAnimator;
    
    public void OnPointerDown(PointerEventData data)
    {
        bloodTestAnimator.SetBool("CheckBloodTestTable", true);
        bloodTestAnimator.SetBool("PutBloodTestTable", false);
        audioSource.clip = audio;
        audioSource.Play();
    }

    public void OnPointerExit(PointerEventData data)
    {
        bloodTestAnimator.SetBool("CheckBloodTestTable", false);
        bloodTestAnimator.SetBool("PutBloodTestTable", true);
    }
}
