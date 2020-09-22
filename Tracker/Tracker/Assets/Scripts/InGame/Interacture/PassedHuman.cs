using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassedHuman : MonoBehaviour
{
    public int pos;
    public Animator newsPaper;
    public GameObject newsPaperPannel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pos == 1)
        {
            GameManager.todayPass++;
            if (collision.CompareTag("AbnormalHuman"))
            {
                GameManager.todayPassAbnormal++;
            }
        }
        else if (pos == 2)
        {
            GameManager.todayHospital++;
            if (collision.CompareTag("Human"))
            {
                GameManager.todayNormalHospital++;
            }
        }


        if (GameManager.nowPeopleNum == GameManager.maxPeopleNum)
        {
            Invoke("OpenNewsPaper", 2);
        }
    }


    private void OpenNewsPaper()
    {
        newsPaperPannel.SetActive(true);
        newsPaper.SetBool("NextDay", false);
        newsPaper.SetBool("WatchPaper", true);
    }
}
