using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;

    public float jumpForce;

    private int jumpCount = 0; // 누적 점프 횟수
    private bool isGrounded = false; // 바닥에 닿았는지 여부
    private bool isDead = false; // 사망여부

    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private AudioSource playerAudio;

    private GameObject ground01;
    private GameObject ground02;

    public int plusScore = 1;

    public float Time1;
    public float Time2;
    int score = 0;


    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        ground01 = GameObject.Find("Start Platform");
        ground02 = GameObject.Find("Start Platform (1)");


        if (PlayerPrefs.HasKey("gravity"))
        {
            playerRigidbody.gravityScale = PlayerPrefs.GetFloat("gravity");
        }
        if (PlayerPrefs.HasKey("jumpForce"))
        {
            jumpForce = PlayerPrefs.GetFloat("jumpForce");
        }
    }

// Update is called once per frame
private void Update()
    {
        if (isDead)
        {
            return;
        }

        //iterate++;
        //if (iterate == 2)
        //{
        //    GameManager.instance.AddScore(plusScore);
        //    iterate = 0;
        //}


        if (Time2 < Time.time)
        {
            GameManager.instance.AddScore(plusScore);
            // Time1 = 0.01f;                                  //반복시간//
            Time2 = Time1 + Time.time;
        }

        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            //playerRigidbody.velocity = Vector2.zero;
            //playerRigidbody.AddForce(new Vector2(0, jumpForce));
            playerRigidbody.velocity = new Vector2(0, jumpForce);
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        //else if (Input.GetMouseButtonUp(0))
        //{
        //    playerRigidbody.velocity = playerRigidbody.velocity * -0.5f;
        //}


        animator.SetBool("Grounded", isGrounded);
    }

    private void Die()
    {
        animator.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigidbody.velocity = Vector2.zero;
        isDead = true;

        GameManager.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !isDead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject == ground01 || collision.collider.gameObject == ground02)
        {
            if (jumpCount > 0)
            {
                isGrounded = false;
            }
        }
        else
        {
            isGrounded = false;
        }
    }
}
