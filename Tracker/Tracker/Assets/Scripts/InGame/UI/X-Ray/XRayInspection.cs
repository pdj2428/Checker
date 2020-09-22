using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class XRayInspection : MonoBehaviour
{
    public Animator xRayAnimator;
    public void Activation()
    {
        if (xRayAnimator.GetBool("InActivation") && xRayAnimator.GetBool("Check") == false)
        {
            xRayAnimator.SetBool("CheckOut", false);
            xRayAnimator.SetBool("Activation", true);
            xRayAnimator.SetBool("InActivation", false);
        }
        else if (xRayAnimator.GetBool("InActivation") == false)
        {
            xRayAnimator.SetBool("Activation", false);
            xRayAnimator.SetBool("InActivation", true);
        }
    }
}
