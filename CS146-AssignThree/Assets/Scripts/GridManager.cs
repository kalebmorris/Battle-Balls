using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public Material purpleMat;

    public void ResetGrid() {
        foreach (Transform child in transform) {
            child.gameObject.GetComponent<Renderer>().material = purpleMat;
        }
    }
}
