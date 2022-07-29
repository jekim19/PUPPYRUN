using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float width;

    public static int obstacleCount = 0;

    public GameObject[] obstacles;

    public GameManager GM;

    public bool isMushroom = false;

    //public int obstacleNumber;

    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    private void Update()
    {
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        //if (obstacles[1].activeSelf == true)
        //{
        //    for (int i = 0; i < 50; i++) {
        //        GM.AddScore(1);
        //    }
        //}

        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
        SetObstacles();
    }

    public void SetObstacles()
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (obstacleCount==3)
            {
                obstacles[i].SetActive(false);
                obstacleCount = 0;
                continue;
            }

            if (Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
                //obstacleNumber = Random.Range(0, 3);
                //switch(obstacleNumber)
                //{
                //    case 0:

                //}
                obstacleCount++;
            }
            else
            {
                obstacles[i].SetActive(false);
                obstacleCount = 0;
            }
        }
    }
}
