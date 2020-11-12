using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public Nensi nensi;

    // Use this for initialization
    void Start()
    {

        nensi = gameObject.GetComponentInParent<Nensi>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger == false)
        nensi.grounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            nensi.grounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            nensi.grounded = false;
    }
}