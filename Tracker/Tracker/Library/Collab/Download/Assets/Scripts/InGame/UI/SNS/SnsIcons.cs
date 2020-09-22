using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnsIcons : MonoBehaviour, IPointerExitHandler
{ 
    public Animator snsAnimator;

    public void Naver()
    {
        snsAnimator.SetBool("TurnNaver", true);
        snsAnimator.SetBool("TurnOffTablet", false);
    }
    public void FaceBook()
    {
        snsAnimator.SetBool("TurnFaceBook", true);
        snsAnimator.SetBool("TurnOffTablet", false);
    }
    public void Twitter()
    {
        snsAnimator.SetBool("TurnTwitter", true);
        snsAnimator.SetBool("TurnOffTablet", false);
    }

    public void OnPointerExit(PointerEventData data)
    {
        snsAnimator.SetBool("TurnOffTablet", true);
        snsAnimator.SetBool("TurnNaver", false);
        snsAnimator.SetBool("TurnFaceBook", false);
        snsAnimator.SetBool("TurnTwitter", false);
    }
}
