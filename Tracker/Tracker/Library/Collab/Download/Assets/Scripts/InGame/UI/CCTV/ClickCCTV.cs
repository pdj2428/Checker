using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickCCTV : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public int cctvNum;

    public Animator cctvAnimator;

    public void OnPointerDown(PointerEventData data)
    {
        cctvAnimator.SetBool("AfterCheckCCTV" + cctvNum.ToString(), false);
        cctvAnimator.SetBool("CheckCCTV" + cctvNum.ToString(), true);
    }

    public void OnPointerExit(PointerEventData data)
    {
        cctvAnimator.SetBool("CheckCCTV" + cctvNum.ToString(), false);
        cctvAnimator.SetBool("AfterCheckCCTV" + cctvNum.ToString(), true);
    }
}
