using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    public int Health = 100;
    private AudioSource audioSource;
    private bool ready = false;
    public GameMaster gameMaster;

    // Update is called once per frame
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void Update()
    {
        if (Health <= 0 && ready == true)
        {

            Destroy(gameObject);

        }

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Nensi" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Zvuk");
            Health -= 20;
            audioSource.Play();
            ready = true;
            gameMaster.Score += 5;

        }
    }

    void Damage(int damage)
    {
        Health -= damage;
    }
}
