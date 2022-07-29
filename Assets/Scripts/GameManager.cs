using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // public AudioClip buttonClip;

    public bool isGameover = false;
    public Text scoreText;
    public Text gameoverScoreText;
    public Text highScoreText;
    public GameObject scoreUI;
    public GameObject gameoverUI;
    public GameObject speedupUI;

    private int score = 0;

    private AudioSource stageBGM;

    private ScrollingObject[] ScObj = new ScrollingObject[4];

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }

        ScObj[0] = GameObject.Find("Start Platform").GetComponent<ScrollingObject>();
        ScObj[1] = GameObject.Find("Start Platform (1)").GetComponent<ScrollingObject>();
        ScObj[2] = GameObject.Find("Sky").GetComponent<ScrollingObject>();
        ScObj[3] = GameObject.Find("Sky (1)").GetComponent<ScrollingObject>();

        stageBGM = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (isGameover && Input.GetMouseButtonDown(0))
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    }

        
    //}

    public void ReLoadGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("GameTitle");
    }

    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "점수 : " + score;
            if (score >= 1 && score % 1000 == 0)            // 1000점마다 10%씩 가속
            {
                for (int i = 0; i < ScObj.Length; i++)
                {
                    ScObj[i].speed *= 1.1f;
                    speedupUI.SetActive(true);
                    Invoke("DisableSpeedupUI", 2f);
                }
            }
        }
    }

    public void DisableSpeedupUI()
    {
        speedupUI.SetActive(false);
    }

    public void OnPlayerDead()
    {
        isGameover = true;
        stageBGM.Stop();
        scoreUI.SetActive(false);
        speedupUI.SetActive(false);
        gameoverUI.SetActive(true);
        gameoverScoreText.text = "점수 : " + score;
        SaveScore();
    }

    public void SaveScore()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score>PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
                gameoverScoreText.text += " (최고기록 경신!)";
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        highScoreText.text = "최고기록 : " + PlayerPrefs.GetInt("highScore");
    }
}
