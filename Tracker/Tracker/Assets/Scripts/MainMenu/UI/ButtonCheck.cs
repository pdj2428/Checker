using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCheck : MonoBehaviour
{
    public GameObject Toggle;

    public void ToggleOn()
    {
        Toggle.GetComponent<Toggle>().isOn = true;
    }

    public void ToggleOff()
    {
        Toggle.GetComponent<Toggle>().isOn = false;
    }

    
}
