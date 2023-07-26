using UnityEngine;
using System.Collections;

public class AsteroidRotate : MonoBehaviour
{
    [SerializeField]
    private float tumble = 1;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Game Over");
    }
}