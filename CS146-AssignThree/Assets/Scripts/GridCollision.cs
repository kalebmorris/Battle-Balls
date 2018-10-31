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

    public Transform explosionBlue;
    public Transform explosionRed;
    public Transform blueDeathEffect;
    public Transform redDeathEffect;

    public Material blue1Transparent;
    public Material blue2Transparent;
    public Material red1Transparent;
    public Material red2Transparent;

    public static bool collided = false;




    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Ball":
                Renderer re = GetComponent<Renderer>();
                re.material = redMat;
                Destroy(other.gameObject);
                Instantiate(explosionRed, other.gameObject.transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity);
                break;
            case "Ball1":
                re = GetComponent<Renderer>();
                re.material = blueMat;
                Destroy(other.gameObject);
                Instantiate(explosionBlue, other.gameObject.transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity);
                break;
            case "Player1":
                Debug.Log(blueMat.name);
                if (GetComponent<Renderer>().material.name.Substring(0, 7).Equals(blueMat.name) && !collided)
                {
                    //print("happeningbeforecoroutine");
                    //Debug.Log("playersteppedinblue");
                    collided = true;

                    StartCoroutine(UponEnter(other.gameObject, redDeathEffect, player2Score, gameObject));

                }
                break;
            case "Player2":
                if (GetComponent<Renderer>().material.name.Substring(0, 6).Equals(redMat.name) && !collided)
                {
                    //.Log("playersteppedinred");
                    collided = true;

                    StartCoroutine(UponEnter(other.gameObject, blueDeathEffect, player1Score, gameObject));
                }
                break;
        }
    }

    public void PlayCoroutine(GameObject obj, Transform effect, Text playerText, GameObject platform) {
        StartCoroutine(UponEnter(obj, effect, playerText, platform));
    }

    public IEnumerator UponEnter(GameObject obj, Transform effect, Text playerText, GameObject platform) {
        SkinnedMeshRenderer[] avatar = obj.GetComponentsInChildren<SkinnedMeshRenderer>();

        for (float f = 1f; f >= -0.1f; f -= 0.2f)
        {
            if (obj.tag == "Player1") {
                avatar[0].material = red1Transparent;
                avatar[1].material = red2Transparent;
            } else if (obj.tag == "Player2") {
                avatar[0].material = blue1Transparent;
                avatar[1].material = blue2Transparent;
            }
            
            Color color1 = avatar[0].material.color;
            Color color2 = avatar[1].material.color;
            color1.a = f;
            color2.a = f;
            avatar[0].material.color = color1;
            avatar[1].material.color = color2;

            yield return new WaitForSeconds(0.001f);
        }
        //}

        yield return new WaitForSeconds(0.135f);
        //obj.gameObject.SetActive(false);
        playerText.text = (Int32.Parse(playerText.text) + 1).ToString();
        //print("happening");
        //obj.SetActive(false);
        Transform death_effect = Instantiate(effect, platform.transform.position + new Vector3(0, 1.01f, 0), Quaternion.Euler(new Vector3(-90f, 0f, 0f)));
        obj.SetActive(false);
        yield return new WaitForSeconds(2f);
        //obj.SetActive(true);

        //Debug.Log("death effect destroyed");
        //Destroy(death_effect.gameObject);
        env.GetComponent<EnvironmentManager>().ResetEnvironment();
        collided = false;

    }
}
