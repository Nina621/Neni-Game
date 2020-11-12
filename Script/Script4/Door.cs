using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    public int LevelLoad = 5;
    public GameMaster gameMaster;

	// Use this for initialization
	void Start () {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
		
	}
	
	
	private void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Nensi"))
        {
            saveScore();
            gameMaster.Inputtext.text = ("Press E to enter");
        }

	}

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Nensi"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                saveScore();
                SceneManager.LoadScene(LevelLoad);
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
        PlayerPrefs.SetInt("Score", gameMaster.Score);
    }
}
