using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene;
        scene = SceneManager.GetActiveScene();
        currentLevel = scene.buildIndex;
    }
}
