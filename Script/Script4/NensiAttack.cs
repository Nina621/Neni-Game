using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NensiAttack : MonoBehaviour {
    public float attackdelay = 0.3f;
    public bool attacking = false;

    public Animator animator;

    

	// Use this for initialization
	private void Awake ()
    {
        animator = gameObject.GetComponent<Animator>();
     
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && !attacking)
        {
            attacking = true;
            attackdelay = 0.3f;
        }
        if (attacking)
        {
            if(attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;
            }
            else
            {
                attacking = false;
          
            }

        }
        animator.SetBool("Attacking", attacking);
	}
}
