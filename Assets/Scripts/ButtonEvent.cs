using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public GameObject text;
    public GameObject face;

    public void PointerEnter()
    {
        text.SetActive(false);
        face.SetActive(true);
    }

    public void PointerExit()
    {
        face.SetActive(false);
        text.SetActive(true);
    }

}
