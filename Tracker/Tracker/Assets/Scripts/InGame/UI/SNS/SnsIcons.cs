using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnsIcons : MonoBehaviour
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

    public void Exit()
    {
        snsAnimator.SetBool("TurnOffTablet", true);
        snsAnimator.SetBool("TurnNaver", false);
        snsAnimator.SetBool("TurnFaceBook", false);
        snsAnimator.SetBool("TurnTwitter", false);
    }
}
