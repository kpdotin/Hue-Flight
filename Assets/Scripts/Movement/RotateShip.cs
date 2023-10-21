using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShip : MonoBehaviour
{

    [SerializeField] MovementScript movementScript;


    private void OnEnable()
    {
        movementScript.RotatingLeft += RotateLeft;
        movementScript.RotatingRight += RotateRight;
    }

    private void OnDisable()
    {
        movementScript.RotatingLeft -= RotateLeft;
        movementScript.RotatingRight -= RotateRight;
    }

    void RotateRight()
    {
        //transform.DOLocalRotate(new Vector3(-45, 90, 90), 0.5f, RotateMode.Fast);
        //Vector3 currentAngle = new Vector3(
        //    Mathf.LerpAngle(-90, -45, 1),
        //    Mathf.LerpAngle(90, 90, 1),
        //    Mathf.LerpAngle(90, 90, 1)
        //    );
        //transform.localEulerAngles = currentAngle;

    }

    void RotateLeft()
    {
        //transform.DOLocalRotate(new Vector3(-135, 90, 90), 0.5f, RotateMode.Fast);
    }
}
