using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BloodTestTableSD : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public Text bloodTestText;
    public Animator bloodTestAnimator;

    public void OnPointerDown(PointerEventData data)
    {
        bloodTestAnimator.SetBool("CheckBloodTestTable", true);
        bloodTestAnimator.SetBool("PutBloodTestTable", false);
        bloodTestText.text = "";
    }

    public void OnPointerExit(PointerEventData data)
    {
        bloodTestAnimator.SetBool("CheckBloodTestTable", true);
        bloodTestAnimator.SetBool("PutBloodTestTable", false);
    }
}
