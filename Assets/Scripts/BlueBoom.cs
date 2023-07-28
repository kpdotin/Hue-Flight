using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBoom : MonoBehaviour
{
    private ColorChange colorChangeScript;

    private void Start()
    {
        colorChangeScript = FindObjectOfType<ColorChange>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(!colorChangeScript.toggleColor)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }
}
