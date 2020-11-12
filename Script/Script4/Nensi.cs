using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nensi : MonoBehaviour
{

    public float speed = 60f, maxspeed = 6, maxjump = 7, jumpPow = 230f;
    public bool grounded = true, faceright = true, doubleJump = false;

    public int ourHealth;
    public int maxHealth = 6;

    public Rigidbody2D rigidBody;
    public Animator animator;
    public GameMaster gameMaster;



    // Use this for initialization
    void Start()
    {

        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

        ourHealth = maxHealth;


    }

    // Update is called once per frame
    void Update()
    {
        // Animator
        animator.SetBool("Grounded", grounded);
        animator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));


        //Skakanje 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doubleJump = true;
                rigidBody.AddForce(Vector2.up * jumpPow);
            }

            else
            {
                if (doubleJump)
                {
                    doubleJump = false;
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
                    rigidBody.AddForce(Vector2.up * jumpPow * 1.2f);

                }
            }
        }
    }

    void FixedUpdate()
    {
        
        float h = Input.GetAxis("Horizontal");
        rigidBody.AddForce((Vector2.right) * speed * h);

        if (rigidBody.velocity.x > maxspeed)
            rigidBody.velocity = new Vector2(maxspeed, rigidBody.velocity.y);

        if (rigidBody.velocity.x < -maxspeed)
            rigidBody.velocity = new Vector2(-maxspeed, rigidBody.velocity.y);


        if (rigidBody.velocity.y > maxjump)
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, maxjump);

        if (rigidBody.velocity.y < -maxjump)
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, -maxjump);


        if (h > 0 && !faceright)
        {
            Flip();
        }

        if (h < 0 && faceright)
        {
            Flip();
        }

        if (grounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x * 0.7f, rigidBody.velocity.y);
        }

        if (ourHealth <= 0)
        {
            Death();
        }
    }

    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (PlayerPrefs.GetInt("highscore") < gameMaster.Score)
            PlayerPrefs.SetInt("highscore", gameMaster.Score);
    }

    public void Damage(int damage)
    {
        ourHealth -= damage;
        
        gameObject.GetComponent<Animation>().Play("redflash");
    }

    public void Knockback(float Knockpow, Vector2 Knockdir)
    {
        rigidBody.velocity = new Vector2(0, 0);
        rigidBody.AddForce(new Vector2(Knockdir.x * -100, Knockdir.y * Knockpow));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coins"))
        {


            gameMaster.Score += 1;
        }


    }
}