using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private float timedelay = 1.5f;

    // Use this for initialization
    void Start()
    {

        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Nensi"))
        {
            StartCoroutine(fall());
        }

    }
    IEnumerator fall()
    {
        yield return new WaitForSeconds(timedelay);
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;

    }
}

