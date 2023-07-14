using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float forwardSpeed;
    private InputManager inputManager;
    Rigidbody rb;
    [SerializeField] bool rightTap = false;
    [SerializeField] bool leftTap = false;
    [SerializeField] bool canceled = true;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
    }
    private void OnEnable()
    {
        inputManager.OnTouchStarted += TouchStarted;
        inputManager.OnRightTap += OnRightTap;
        inputManager.OnLeftTap += OnLeftTap;
        inputManager.OnTouchCanceled += TouchCanceled;
    }
    private void OnDisable()
    {
        inputManager.OnTouchStarted -= TouchStarted;
        inputManager.OnRightTap -= OnRightTap;
        inputManager.OnLeftTap -= OnLeftTap;
        inputManager.OnTouchCanceled -= TouchCanceled;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(!canceled)
        {
            if (leftTap)
            {
                rb.velocity = transform.TransformDirection(new Vector3(movementSpeed * (-1), 0, movementSpeed));
                rb.AddRelativeForce(Vector3.forward * forwardSpeed, ForceMode.VelocityChange);
                
            }


            if (rightTap)
            {
                rb.velocity = transform.TransformDirection(new Vector3(movementSpeed, 0, movementSpeed));
                rb.AddRelativeForce(Vector3.forward * forwardSpeed, ForceMode.VelocityChange);
                

            }
        }
    }


    void OnRightTap()
    {
        rightTap = true;
    }

    void OnLeftTap()
    {
        leftTap = true;
    }
    void TouchStarted()
    {
         canceled = false;
    }
    void TouchCanceled()
    {
        rightTap = false;
        leftTap = false;
        canceled = true;
    }
}
