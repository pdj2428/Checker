using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{

    public GameObject GameStart;
    public GameObject[] Gobject;
    public void Buttondisable() // 게임시작시 버튼 숨기기
    {
        for (int i = 0; i < Gobject.Length; i++)
        {
            Gobject[i].SetActive(false);
        }
    }

    public void GameStartdisable() // 게임 시작 이후 페이드 아웃 없애기
    {
        GameStart.SetActive(false);
    }

    public void Ending()
    {
        SceneManager.LoadScene("Ending");
    }

    public void QuitGame() // 게임 종료 버튼
    {
        Application.Quit();
    }
}
