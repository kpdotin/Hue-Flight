using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InputManager;

public class ColorChange : MonoBehaviour
{
    bool toggleColor = false;
    private Material playerMat;
    private void Start()
    {
        playerMat = GetComponent<Renderer>().material;
    }
    public void ChangeColor()
    {
        toggleColor = !toggleColor;
    }

    private void Update()
    {
        if (!toggleColor)
        {
            playerMat.color = new Color(1, 0, 0);
        }
        else
        {
            playerMat.color = new Color(0, 0.2694f, 1);
        }
    }
}
