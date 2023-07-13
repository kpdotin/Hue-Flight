using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float forwardSpeed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) 
        { 
            rb.velocity = transform.TransformDirection( new Vector3(movementSpeed * (-1),0,movementSpeed));
            rb.AddRelativeForce(Vector3.forward * forwardSpeed,ForceMode.VelocityChange);
        }


        if (Input.GetKey(KeyCode.RightArrow)) 
        { 
            rb.velocity = transform.TransformDirection( new Vector3(movementSpeed,0,movementSpeed));
            rb.AddRelativeForce(Vector3.forward * forwardSpeed, ForceMode.VelocityChange);

        }
    }
}
