using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int damage = 20;

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private BoxCollider2D boxCollider2D;
    private bool ReadyToDestroy;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (ReadyToDestroy == true && audioSource.isPlaying == false)
        {
            Destroy(this);
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
           // col.SendMessageUpwards("Damage", damage);
        }

        if (col.gameObject.tag == "Nensi")
        {
            ReadyToDestroy = true;
            audioSource.Play();
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
        }
    }

}
