using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoom : MonoBehaviour
{
    private ColorChange colorChangeScript;

    private void Start()
    {
        colorChangeScript = FindObjectOfType<ColorChange>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (colorChangeScript.toggleColor && other.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(10);
        }
    }

    
}
