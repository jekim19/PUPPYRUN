using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    public float volume;

    // Start is called before the first frame update
    public void BGMControl()
    {
        float volume = slider.value;

        if (volume == -30f)
        {
            mixer.SetFloat("BGM", -80);
        }
        else
        {
            mixer.SetFloat("BGM", volume);
        }

        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SFXControl()
    {
        float volume = slider.value;

        if (volume == -30f)
        {
            mixer.SetFloat("SFX", -80);
        }
        else
        {
            mixer.SetFloat("SFX", volume);
        }

        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

}
