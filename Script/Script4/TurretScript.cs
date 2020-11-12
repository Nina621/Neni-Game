using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour {
    public int cureHelth = 100;

    public float distance;
    public float wakerange;
    public float shootInterval;
    public float bulletSpeed = 5;
    public float bulletTimer;

    
    public bool awake = false;
    public bool lookingRight = true;

    public GameObject bullet;
    public Transform target;
    public Animator animator;
    public Transform shootPointL,shootPointR;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        animator.SetBool("Awake", awake);
        animator.SetBool("LookRight", lookingRight);

        RangeCheck();

        if (target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        
        }


        if (target.transform.position.x < transform.position.x)
        {
            lookingRight = false;

        }
        if (cureHelth < 0)
        {
            Destroy(gameObject);
        }
    }
    void RangeCheck()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < wakerange)
            awake = true;

        if (distance > wakerange)
            awake = false;
    }

    public void Attack(bool attackRight)
    {
        bulletTimer += Time.deltaTime;

        if(bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if (attackRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointR.transform.position, shootPointR.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0;
            }

            if (!attackRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointL.transform.position, shootPointL.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0;
            }
        }
    }
}
