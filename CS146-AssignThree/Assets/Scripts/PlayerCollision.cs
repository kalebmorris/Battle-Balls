using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    private GameObject currPlatform;
    public GridCollision gridCollision;
    // Use this for initialization

    private void OnTriggerStay(Collider other)
    {
        currPlatform = other.gameObject;
    }
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision entered");
        if (collision.gameObject.tag == "Ball1" || collision.gameObject.tag == "Ball") {
            GridCollision.collided = true;
            //.Log("a ball hit");
            Destroy(collision.gameObject);
            if (gameObject.tag == "Player1") {

                //Debug.Log("hit1");
                gridCollision.StartCoroutine(gridCollision.UponEnter(gameObject, gridCollision.redDeathEffect, gridCollision.player2Score, currPlatform));
            } else if (gameObject.tag == "Player2") {
                //Debug.Log("hit2");
                //gridCollision.collided = true;
                gridCollision.StartCoroutine(gridCollision.UponEnter(gameObject, gridCollision.blueDeathEffect, gridCollision.player1Score, currPlatform));
            }
        }
    }
}
