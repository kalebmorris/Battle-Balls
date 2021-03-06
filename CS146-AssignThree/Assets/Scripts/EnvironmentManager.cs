﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour {

    public Transform Player1;
    public Transform Player2;
    public GameObject HexGrid;

    public Material originalBlue1;
    public Material originalBlue2;
    public Material originalRed1;
    public Material originalRed2;

   

    public void ResetEnvironment() {
        SkinnedMeshRenderer[] avatar1 = Player1.GetComponentsInChildren<SkinnedMeshRenderer>();
        SkinnedMeshRenderer[] avatar2 = Player2.GetComponentsInChildren<SkinnedMeshRenderer>();
        //Debug.Log(avatar1[0].material.color.a);
        //Debug.Log(avatar1[1].material.color.a);
        //Debug.Log(color2);
       
        //FindObjectOfType<GridCollision>().collided = false;
        avatar1[0].material = originalRed1;
        avatar1[1].material = originalRed2;
        avatar2[0].material = originalBlue1;
        avatar2[1].material = originalBlue2;
        //Player1.gameObject.SetActive(true);
        Player1.SetPositionAndRotation(new Vector3(-6.2f, 1f, 0f), Quaternion.Euler(0, 0, 0));
        Player2.SetPositionAndRotation(new Vector3(6.2f, 1f, 0f), Quaternion.Euler(0, 0, 0));
        Player1.gameObject.SetActive(true);
        Player2.gameObject.SetActive(true);
        GameObject[] balls1 = GameObject.FindGameObjectsWithTag("Ball1");
        for (int i = 0; i < balls1.Length; i++) {
            print("destroyed ball1");
            Destroy(balls1[i]);
        }
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        for (int i = 0; i < balls.Length; i++)
        {
            Destroy(balls[i]);
            print("destroyed ball");
        }
        GameObject[] effects = GameObject.FindGameObjectsWithTag("effect");
        for (int i = 0; i < effects.Length; i++)
        {
            Destroy(effects[i]);
            print("destroyed effect");
        }
        HexGrid.GetComponent<GridManager>().ResetGrid();
    }
}
