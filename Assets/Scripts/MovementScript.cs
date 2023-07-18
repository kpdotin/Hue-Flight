using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float forwardSpeed;
    [SerializeField] Transform ship;

    private InputManager inputManager;
    Rigidbody rb;
    bool rightTap = false;
    bool leftTap = false;
    bool canceled = true;
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
        float rotateZ =  ship.localRotation.eulerAngles.z;
        float rotateY = ship.localRotation.eulerAngles.y;
        float rotateX = ship.localRotation.eulerAngles.x;
        if (!canceled)
        {
            if (leftTap)
            {
                rb.velocity = transform.TransformDirection(new Vector3(movementSpeed * (-1), 0, movementSpeed));
                rb.AddRelativeForce(Vector3.forward * forwardSpeed, ForceMode.VelocityChange);
                ship.Rotate(0, 7, 0);
                //float roll = Mathf.Lerp(-90, -120, 1);
                //ship.localRotation = Quaternion.Euler(Vector3.forward * roll);
                
            }


            if (rightTap)
            {
                rb.velocity = transform.TransformDirection(new Vector3(movementSpeed, 0, movementSpeed));
                rb.AddRelativeForce(Vector3.forward * forwardSpeed, ForceMode.VelocityChange);
                ship.Rotate(0, -7, 0);
                //float roll = Mathf.Lerp(-90, -60, 1);
                //ship.localRotation = Quaternion.Euler(Vector3.forward * roll);

            }
        }
        if (canceled)
        {
            ship.localRotation = Quaternion.Euler(-90,90,90);
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
