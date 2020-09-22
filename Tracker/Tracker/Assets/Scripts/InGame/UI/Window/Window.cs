using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Window : MonoBehaviour, IPointerDownHandler
{
    private bool click = false;
    public GameObject[] gameObjects;

    public void OnPointerDown(PointerEventData data)    
    {
        click = !click;
        if(click)
        {
            gameObjects[0].SetActive(true);
            gameObjects[1].SetActive(true);
        }
        else
        {
            gameObjects[0].SetActive(false);
            gameObjects[1].SetActive(false);
        }
    }
}
