using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackClone : MonoBehaviour {
    public TurretScript turret;
    public bool isLeft;

	// Use this for initialization
	private void Awake () {
        turret = gameObject.GetComponentInParent<TurretScript>();
	}
	
	// Update is called once per frame
	private void OnTriggerStay2D (Collider2D col)
    {
        if (col.CompareTag("Nensi"))
        {
            if (isLeft)
                turret.Attack(false);

            else
                turret.Attack(true);
            
        }
    }
		
	
}
