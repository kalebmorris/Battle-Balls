using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour {

    public Transform Player1;
    public Transform Player2;
    public GameObject HexGrid;

    public void ResetEnvironment() {
        Player1.SetPositionAndRotation(new Vector3(-6.2f, 1f, 0f), Quaternion.Euler(0, 0, 0));
        Player2.SetPositionAndRotation(new Vector3(6.2f, 1f, 0f), Quaternion.Euler(0, 0, 0));
        HexGrid.GetComponent<GridManager>().ResetGrid();
    }
}
