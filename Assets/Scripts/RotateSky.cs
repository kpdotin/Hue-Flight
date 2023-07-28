using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSky : MonoBehaviour
{
    [SerializeField]
    private float tumble = 1;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity =  Vector3.down * tumble;
    }
}
