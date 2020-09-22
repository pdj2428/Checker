using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    public AudioSource musicsource;
    public GameObject setting;
    private bool set = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && set == false)
        {
            setting.SetActive(true);
            set = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && set == true)
        {
            setting.SetActive(true);
            set = false;
        }
    }
    public void SetMusicVolum(float volum)
    {
        musicsource.volume = volum;
    }

    public void Exit()
    {
        set = false;
        setting.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
