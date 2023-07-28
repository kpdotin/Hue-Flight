using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPower : MonoBehaviour
{
    public delegate void Shield();
    public event Shield shieldEvent;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Vector3.up * 0.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        shieldEvent();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
