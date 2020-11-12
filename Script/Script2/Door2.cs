using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door2 : MonoBehaviour
{

    public int Levelload = 3;
    public GameMaster gameMaster;

    // Use this for initialization
    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Nensi"))
        {
            saveScore();
            gameMaster.Inputtext.text = ("Press E to Enter");
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Nensi"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                saveScore();
                SceneManager.LoadScene(Levelload);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Nensi"))
        {
            gameMaster.Inputtext.text = ("");
        }
    }

    void saveScore()
    {
        PlayerPrefs.SetInt("points", gameMaster.Score);
    }
}