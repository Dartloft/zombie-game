using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public static bool gameover;

    public GameObject gameoverpanel;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            Time.timeScale = 0;
            gameoverpanel.SetActive(true);
            
        }
       
    }

    public void retry()
    {
        SceneManager.LoadScene("Game");
    }

    public void quit()
    {
        Application.Quit();
        
    }
}
