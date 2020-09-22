using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IDCard : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public Text[] directiveText;
    public Animator directiveAnimator;

    //사람이 들어올 때 IDCard를 받는 애니메이션과 다시 IDCard를 되돌려 주는 애니메이션은 다른 사람과 상호작용 코드를 만들 때 사람이 통과 또는 돌아가려고 할 때 반환, 이미지도 그쪽에서 반환
    public void OnPointerDown(PointerEventData data)
    {
        directiveAnimator.SetBool("CheckIDCard", true);
        directiveAnimator.SetBool("PutIDCard", false);
    }

    public void OnPointerExit(PointerEventData data)
    {
        directiveAnimator.SetBool("PutIDCard", true);
        directiveAnimator.SetBool("CheckIDCard", false);
    }
}
