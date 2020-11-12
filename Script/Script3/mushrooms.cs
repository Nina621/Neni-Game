using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushrooms : MonoBehaviour
{
    public Nensi nensi;
    public int damage = 2;

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private BoxCollider2D boxCollider2D;
    private bool ReadyToDestroy;

    // Use this for initialization
    void Start()
    {
        nensi = GameObject.FindGameObjectWithTag("Nensi").GetComponent<Nensi>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        boxCollider2D = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Nensi"))
        {

            audioSource.Play();
            spriteRenderer.enabled = true;
            boxCollider2D.enabled = true;

            nensi.Damage(damage);
            nensi.Knockback(400f, nensi.transform.position);
        }

    }
}
