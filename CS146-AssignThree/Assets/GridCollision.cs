using System;
using System.Collections;
using System.Collections.Generic;
using ProBuilder.Core;
using UnityEngine;
using UnityEngine.UI;

public class GridCollision : MonoBehaviour {
    public Material redMat;
    public Material blueMat;
    public Text player1Score;
    public Text player2Score;
    public GameObject env;

    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Ball":
                Renderer re = GetComponent<Renderer>();
                re.material = redMat;
                Destroy(other.gameObject);
                break;
            case "Ball1":
                re = GetComponent<Renderer>();
                re.material = blueMat;
                Destroy(other.gameObject);
                break;
            case "Player1":
                if (GetComponent<Renderer>().material.color.Equals(blueMat.color))
                {
                    player2Score.text = (Int32.Parse(player2Score.text) + 1).ToString();
                    env.GetComponent<EnvironmentManager>().ResetEnvironment();
                }
                break;
            case "Player2":
                if (GetComponent<Renderer>().material.color.Equals(redMat.color))
                {
                    player1Score.text = (Int32.Parse(player1Score.text) + 1).ToString();
                    env.GetComponent<EnvironmentManager>().ResetEnvironment();
                }
                break;
        }
    }
}
