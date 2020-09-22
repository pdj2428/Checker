 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassedHuman : MonoBehaviour
{
    public Animator[] animator;
    public GameObject pannel;
    public Animator newsPaper;
    public GameObject newsPaperPannel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        pannel.SetActive(true);
        animator[0].SetBool("CheckBloodTestTable", false);
        animator[0].SetBool("PutBloodTestTable", false);
        animator[0].SetBool("BloodTest", false);
        animator[0].SetBool("ChangeSyringe", true);

        animator[1].SetBool("GetIDCard", false);
        animator[1].SetBool("TakeBackIDCard", true);

        animator[2].SetBool("Check", false);
        animator[2].SetBool("AfterCheck", true);

        if (collision.CompareTag("AbnormalHuman"))
        {
            PlayerPrefs.SetInt("PassedAbnormalHuman", PlayerPrefs.GetInt("PassedAbnormalHuman") + 1);
        }
        Invoke("ClosePannel", 3);

        if(GameManager.nowPeopleNum == GameManager.maxPeopleNum)
        {
            Invoke("OpenNewsPaper", 2);
        }
    }

    private void ClosePannel()
    {
        pannel.SetActive(false);
    }

    private void OpenNewsPaper()
    {
        newsPaperPannel.SetActive(true);
        newsPaper.SetBool("NextDay", false);
        newsPaper.SetBool("WatchPaper", true);
    }
}
