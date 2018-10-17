using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine;


public class ClockScript : MonoBehaviour
{

    public int timeRemaining;
    public Text clock;
    public GameObject gameOverUI;

    public Text player1Score;
    public Text player2Score;
    public Text player1Wins;
    public Text player2Wins;

    private bool gameOver = false;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("LoseTime");
    }

    // Update is called once per frame
    void Update()
    {
        int seconds = (timeRemaining % 60);
        int minutes = (timeRemaining - seconds) / 60;
        if (seconds < 10)
        {
            clock.text = minutes.ToString("0") + ":0" + seconds.ToString("0");
        }
        else
        {
            clock.text = minutes.ToString("0") + ":" + seconds.ToString("0");
        }

        if (timeRemaining <= 0 && !gameOver)         {             StopCoroutine("LoseTime");             clock.text = "0:00";             DisplayGameOver();         }     }


    void DisplayGameOver()
    {         gameOver = true;          int score1 = Int32.Parse(player1Score.text);         int score2 = Int32.Parse(player2Score.text);          gameOverUI.SetActive(true);         if (score1 > score2)         {             Debug.Log("Player1 wins");             player1Wins.gameObject.SetActive(true);         }         else if (score2 > score1)         {             Debug.Log("Player2 wins");             player2Wins.gameObject.SetActive(true);         }     } 

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
        }
    }

}
