using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperMode : MonoBehaviour
{
    public Text gravity;
    public Text jumpForce;

    public GameObject developerModeWindow;

    // Start is called before the first frame update

    public void DeveloperButton()
    {
        developerModeWindow.SetActive(true);
    }

    //public void DeveloperApply()
    //{
    //}

    public void ApplyButton()
    {
        if (gravity != null)
        {
            PlayerPrefs.SetFloat("gravity", float.Parse(gravity.text));
        }
        if (jumpForce != null)
        {
            PlayerPrefs.SetFloat("jumpForce", float.Parse(jumpForce.text));
        }
        developerModeWindow.SetActive(false);
    }

}
