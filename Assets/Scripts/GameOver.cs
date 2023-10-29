using UnityEngine.SceneManagement;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class GameOver : MonoBehaviour
{
    public void OnMenuClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(LevelManager.currentLevel);
    }

    public void OnNextLevel()
    {
        if(LevelManager.currentLevel+1 == 10)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(LevelManager.currentLevel + 1);
        }
    }
}
