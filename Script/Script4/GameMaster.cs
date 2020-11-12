using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameMaster : MonoBehaviour
{
    public static GameMaster sharedInstance = null;

    public int Score = 0;
    public int highScore = 0;
    bool provjera = false;
    string path;

    public Text pointtext;
    public Text Hightext;
    public Text Inputtext;

    // Use this for initialization
    /*private void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            sharedInstance = this;
        }
    }*/

    void Start()
    {
        //SceneManager.activeSceneChanged += Load;
        path = Application.dataPath + "Save.txt";
        Debug.Log("start");
        Hightext.text = ("HighScore:" + PlayerPrefs.GetInt("highscore"));
        highScore = PlayerPrefs.GetInt("highscore", 0);
        StartCoroutine(SaveGame());
        

        if (PlayerPrefs.HasKey("points"))
        {
            Scene ActiveScreen = SceneManager.GetActiveScene();
            if (ActiveScreen.buildIndex == 1)
            {
                Debug.Log(pointtext.text);
                PlayerPrefs.DeleteKey("points");
                Score = 0;
                highScore = 0;
            }
            else
                Score = PlayerPrefs.GetInt("points");
        }

    }

    void Load(Scene current, Scene next)
    {

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Hightext.text = reader.ReadLine();
        reader.Close();
        Debug.Log("sranje");
    }

    IEnumerator SaveGame()
    {
        while (true)
        {
            Debug.Log("provjera");
            

            if (!File.Exists(path))
            {
                Debug.Log("KURAC");
                File.WriteAllText(path, highScore.ToString());
                provjera = true;
            }

            Debug.Log(provjera.ToString());
            if (provjera == true)
            {
                Debug.Log("PIČKA");
                File.WriteAllText(path, highScore.ToString());
            }

            yield return new WaitForSeconds(10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        pointtext.text = ("Score:" + Score);
    }
}
