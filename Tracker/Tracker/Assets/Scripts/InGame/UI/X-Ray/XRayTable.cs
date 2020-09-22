using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.EventSystems;

public class XRayTable : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public GameObject[] imagePos;
    public void OnPointerDown(PointerEventData data)
    {
        gameObject.transform.position = imagePos[1].transform.position;
        gameObject.transform.localScale = new Vector2(6, 7.5f);
    }

    public void OnPointerExit(PointerEventData data)
    {
        gameObject.transform.position = imagePos[0].transform.position;
        gameObject.transform.localScale = new Vector2(2, 2.5f);
    }

}
