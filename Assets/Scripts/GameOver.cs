using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void OnMenuClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void OnRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(12);

    }
}
