using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerMove : MonoBehaviour
{
    public GameManager gameManager;

    private float addForce = 100f;

    private Rigidbody2D playerRigidbody;

    private Animator animator;

    public int maxLife = 2;

    public int life = 2;

    public bool playerMove = false;
    public bool playerHurt = false;

    private SpriteRenderer spriteRenderer;

    public TextMeshProUGUI lifeText;

    private AudioSource playerAudio;

    public AudioClip coinAudio;

    void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAudio = GetComponent<AudioSource>();
        life = maxLife;

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameover&&playerMove)
            playerRigidbody.AddForce(new Vector2(0, addForce * Time.deltaTime * 60));

        if (playerHurt)
        {
            animator.SetTrigger("Hurt");
            playerHurt = false;
        }
        if (Input.GetKey(KeyCode.P))
        {
            playerRigidbody.AddForce(new Vector2(0, addForce * Time.deltaTime * 60));
        }

    }
    private void FixedUpdate()
    {
        //if (playerMove)
        //    playerRigidbody.AddForce(new Vector2(0, addForce));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "trap")
        {
            if (life == 0)
            {

                animator.SetTrigger("Hurt");
                playerRigidbody.AddForce(new Vector2(-1000, 0));
                gameManager.Die();
                playerAudio.Play();
            }
            else
            {
                gameObject.layer = 11;
                StartCoroutine("OffDamaged");
                spriteRenderer.color = new Color(1, 1, 1, 0.4f);
                LifeText(1);
                animator.SetTrigger("Hurt");
                playerAudio.Play();
            }

        }
        if (collision.tag == "DieLine")
        {
            gameManager.isGameover = true;
            LifeText(10);
            gameManager.Die();
        }

        if (collision.tag == "Treasure")
        {
            collision.gameObject.SetActive(false);
            gameManager.Score(5);
            playerAudio.PlayOneShot(coinAudio);
        }
        Debug.Log(life);
    }
    IEnumerator OffDamaged()
    {
        yield return new WaitForSeconds(3f);
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    private void LifeText(int damage)
    {

        life = life - damage;
        if (life <= 0)
        {
            life = 0;
        }

        lifeText.text = " X " + life;
    }

}
