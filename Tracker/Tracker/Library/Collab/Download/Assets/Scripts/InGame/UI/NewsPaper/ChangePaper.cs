using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangePaper : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public Animator newsPaperAnimator;

    public void OnPointerDown(PointerEventData data)
    {
        newsPaperAnimator.SetBool("AfterCheckNewsPaper", false);
        newsPaperAnimator.SetBool("CheckNewsPaper", true);
    }

    public void OnPointerExit(PointerEventData data)
    {
        if(Input.GetMouseButtonDown(0))
        {
            newsPaperAnimator.SetBool("CheckNewsPaper", false);
            newsPaperAnimator.SetBool("AfterCheckNewsPaper", true);
        }       
    }
}
