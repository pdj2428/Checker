using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextDayButton : MonoBehaviour
{
    public Animator newsPaperPannelAnimator;
    public GameObject Pannel;
    public void PressNextDay()
    {
        newsPaperPannelAnimator.SetBool("WatchPaper", false);
        newsPaperPannelAnimator.SetBool("NextDay", true);
        
        GameObject.Find("GameManager").GetComponent<GameManager>().newDay();
        Invoke("DeletePannel", 3);
    }

    private void DeletePannel()
    {
        Pannel.SetActive(false);
    }
}
