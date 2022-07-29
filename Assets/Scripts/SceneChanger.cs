using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startC;
    public GameObject howtoC;
    public GameObject settingsW;
    public void LoadGame()
    {
        SceneManager.LoadScene("GameStage");
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("GameTitle");
    }

    public void LoadHowto()
    {
        startC.SetActive(false);
        howtoC.SetActive(true);
    }

    public void ExitHowto()
    {
        howtoC.SetActive(false);
        startC.SetActive(true);
    }

    public void LoadSettings()
    {
        settingsW.SetActive(true);
    }

    public void ExitSettings()
    {
        settingsW.SetActive(false);
    }
}
