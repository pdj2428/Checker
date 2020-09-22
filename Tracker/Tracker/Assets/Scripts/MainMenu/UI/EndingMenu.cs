using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingMenu : MonoBehaviour
{
    public Text text;
    public GameObject EndingUI;

    public Button[] EndingButtons; 
    public void Endingmenu()
    {
        if(PlayerPrefs.GetInt("Ending1") == 1 || PlayerPrefs.GetInt("Ending2") == 1 || PlayerPrefs.GetInt("Ending3") == 1)
        {
            EndingUI.SetActive(true);
            if (PlayerPrefs.GetInt("Ending1") == 1)
            {
                PlayerPrefs.SetInt("FromMenu", 1);
                PlayerPrefs.SetInt("SelectEnding", 1);
                EndingButtons[0].interactable = true;
            }
            if (PlayerPrefs.GetInt("Ending2") == 1)
            {
                PlayerPrefs.SetInt("FromMenu", 1);
                PlayerPrefs.SetInt("SelectEnding", 2);
                EndingButtons[1].interactable = true;
            }
            if (PlayerPrefs.GetInt("Ending3") == 1)
            {
                PlayerPrefs.SetInt("FromMenu", 1);
                PlayerPrefs.SetInt("SelectEnding", 3);
                EndingButtons[2].interactable = true;
            }
        }
        else
        {
            text.text = "아직 확인한 엔딩이 없습니다.";
        }
    }

    public void SelectEnding1()
    {
        PlayerPrefs.SetInt("SelectEnding",1);
        SceneManager.LoadScene("Ending");
    }

    public void SelectEnding2()
    {
        PlayerPrefs.SetInt("SelectEnding", 2);
        SceneManager.LoadScene("Ending");
    }

    public void SelectEnding3()
    {
        PlayerPrefs.SetInt("SelectEnding", 3);
        SceneManager.LoadScene("Ending");
    }

}
