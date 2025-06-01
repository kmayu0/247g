using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    // public int score;
    public bool gameOver;
    // public GameObject title;
    // public Text scoreboard;

    void Start()
    {
        // score = 0;
        // title.SetActive(false);
        gameOver = false;
        // scoreboard.text = "0";
    }

    void Update()
    {
        if (gameOver)
{
    // title.SetActive(true);  // Activate the title (game over screen)
    gameOver = false;
}
else
{
    // title.SetActive(false); // Deactivate the title (hide the game over screen)
}
    }

    // public void ScoreAdd()
    // {
    //     score++;
    //     scoreboard.text = score.ToString();
    // }

    public void NewGame()
    {
        SceneManager.LoadScene(0);
    }
}
