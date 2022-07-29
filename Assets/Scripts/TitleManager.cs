using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public Text highScoreText_title;
    public GameObject easterEggUI;
    public Slider BGMSlider;
    public Slider SFXSlider;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText_title.text = "내 최고기록 : " + PlayerPrefs.GetInt("highScore");
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void OpenEasterEgg()
    {
        easterEggUI.SetActive(true);
    }

    public void CloseEasterEgg()
    {
        easterEggUI.SetActive(false);
    }
}
