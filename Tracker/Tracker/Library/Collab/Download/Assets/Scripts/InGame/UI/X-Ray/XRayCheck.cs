using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XRayCheck : MonoBehaviour
{ 
    public Animator xRayAnimator;
    public Button button;
    public void Check()
    {
        button.interactable = true;
        xRayAnimator.SetBool("Check", true);
        xRayAnimator.SetBool("Activation", false);
    }
}
