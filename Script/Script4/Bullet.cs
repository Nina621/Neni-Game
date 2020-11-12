using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifeTime = 2;

	// Use this for initialization
	void Start () {


	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.isTrigger == false)
        {
            if (col.CompareTag("Nensi"))
            {
                col.SendMessageUpwards("Damage",1);
            }
            Destroy(gameObject);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);
		
	}
}
