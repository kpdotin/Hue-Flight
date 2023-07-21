using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InputManager;

public class ColorChange : MonoBehaviour
{
    bool toggleColor = false;
    private Material playerMat;
    [SerializeField] Material Red;
    [SerializeField] Material Blue;
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
            playerMat.color = Red.color;
        }
        else
        {
            playerMat.color = Blue.color;
        }
    }
}
