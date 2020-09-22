using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class XRayTable : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public Image mainImage;
    public Image[] images;
    public GameObject[] imagePos;
    public void OnPointerDown(PointerEventData data)
    {
        gameObject.transform.position = imagePos[1].transform.position;
        gameObject.transform.localScale = new Vector2(6, 7.5f);
        mainImage = images[1];
    }

    public void OnPointerExit(PointerEventData data)
    {
        gameObject.transform.position = imagePos[0].transform.position;
        gameObject.transform.localScale = new Vector2(2, 2.5f);
        mainImage = images[0];
    }

}
