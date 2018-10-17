using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public void Begin()     {         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);     }      public void End()     {         Application.Quit();     }      public void Restart()     {         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);     }
}
