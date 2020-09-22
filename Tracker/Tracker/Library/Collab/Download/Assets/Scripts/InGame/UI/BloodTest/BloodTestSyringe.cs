using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BloodTestSyringe : MonoBehaviour, IPointerDownHandler
{
    public Animator bloodTestAnimator;

    public void OnPointerDown(PointerEventData data)
    {
        bloodTestAnimator.SetBool("BloodTest", true);
        bloodTestAnimator.SetBool("ChangeSyringe", false);
    }
}
