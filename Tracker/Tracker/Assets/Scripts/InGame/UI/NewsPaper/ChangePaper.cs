using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangePaper : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public new AudioClip audio;
    public AudioSource audioSource;

    public Animator newsPaperAnimator;

    public Text[] text;

    private bool change = false;
    public void OnPointerDown(PointerEventData data)
    {
        audioSource.clip = audio;
        audioSource.Play();

        newsPaperAnimator.SetBool("AfterCheckNewsPaper", false);
        newsPaperAnimator.SetBool("CheckNewsPaper", true);
    }

    public void OnPointerExit(PointerEventData data)
    {
            change = true;       
    }

    private void Update()
    {
        if(change && Input.GetMouseButtonDown(0))
        {
            newsPaperAnimator.SetBool("CheckNewsPaper", false);
            newsPaperAnimator.SetBool("AfterCheckNewsPaper", true);
            change = false;
        }
        text[0].text = "오늘 검문소를 통과한\n사람 수     " + GameManager.todayPass.ToString() + "명";
        text[1].text = "오늘 검문소에서 병원으로 이송 된\n사람 수     " + GameManager.todayHospital.ToString() + "명";
        text[2].text = "오늘 검문소를 방문한\n사람 수     " + (GameManager.maxPeopleNum).ToString() + "명";
    }
}
