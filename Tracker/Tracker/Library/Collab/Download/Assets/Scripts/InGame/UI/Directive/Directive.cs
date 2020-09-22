using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Directive : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    public Text directiveText;
    public Animator directiveAnimator;
    public void OnPointerEnter(PointerEventData data)
    {
        
        directiveAnimator.SetBool("PutOutDirective", true);
        directiveAnimator.SetBool("PutInDirective", false);
    }

    public void OnPointerDown(PointerEventData data)
    {
        directiveAnimator.SetBool("AfterReadDirective", false);
        directiveAnimator.SetBool("ReadDirective", true); 
        directiveText.text = "";
    }

    public void OnPointerExit(PointerEventData data)
    {
        if(directiveAnimator.GetBool("ReadDirective"))
        {
            directiveAnimator.SetBool("PutOutDirective", false);
            directiveAnimator.SetBool("ReadDirective", false);
            directiveAnimator.SetBool("AfterReadDirective", true);
        }
        else
        {
            directiveAnimator.SetBool("PutOutDirective", false);
            directiveAnimator.SetBool("PutInDirective", true);
        }      
    }
}
