using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour
{
    public UnityEngine.UI.Image fade;
    public Gamemanager manager;
    public Text text;

    public bool isStart = false;

    float fades = 0f;
    float time = 0;
    bool check;

    public void StartGame()
    {
        isStart = true;
        check = true;
    }

    /*public void StartEnding()
    {
        isStart = true;
        check = false;
    }*/

    void Update()
    {
        if (isStart)
        {
            manager.Buttondisable();
            time += Time.deltaTime;
            if (fades < 1.0f && time >= 0.1f)
            {
                fades += 0.1f;
                fade.color = new Color(0, 0, 0, fades);
                time = 0;
            }
            else if (fades >= 1.0f)
            {
                if (check)
                {
                    SceneManager.LoadScene("InGame");
                }
                
                manager.GameStartdisable();
                isStart = false;
                time = 0;
            }
        }
    }

}
