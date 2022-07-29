using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEggButton : MonoBehaviour
{
    public GameObject easterEggUI;
    public Text couponNumber;

    void OnMouseDown()
    {
        couponNumber.text = "선물 코드 : " + Random.Range(1000, 9999);
        easterEggUI.SetActive(true);
    }

    private void RandomInt()
    {
        System.Random random = new System.Random();
    }
}
