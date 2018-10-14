using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ClockScript : MonoBehaviour
{

    public int timeRemaining;
    public Text clock;

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

        if (timeRemaining <= 0)
        {
            StopCoroutine("LoseTime");
            clock.text = "Time's Up!";
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
        }
    }

}
