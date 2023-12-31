using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float forwardSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] Transform ship;

    //public delegate void RotateRight();
    //public event RotateRight RotatingRight;

    //public delegate void RotateLeft();
    //public event RotateLeft RotatingLeft;

    private StinkyCloudScript cloudScript;
    private InputManager inputManager;
    Rigidbody rb;
    bool rightTap = false;
    bool leftTap = false;
    bool canceled = true;
    bool stinkyCloud = false;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
        cloudScript = FindObjectOfType<StinkyCloudScript>();
    }
    private void OnEnable()
    {
        inputManager.OnTouchStarted += TouchStarted;
        inputManager.OnRightTap += OnRightTap;
        inputManager.OnLeftTap += OnLeftTap;
        inputManager.OnTouchCanceled += TouchCanceled;
        if (cloudScript != null) { cloudScript.OnCloudCollision += ToggleStinkyCloud; }
        
    }
    private void OnDisable()
    {
        inputManager.OnTouchStarted -= TouchStarted;
        inputManager.OnRightTap -= OnRightTap;
        inputManager.OnLeftTap -= OnLeftTap;
        inputManager.OnTouchCanceled -= TouchCanceled;

        if (cloudScript != null) { cloudScript.OnCloudCollision -= ToggleStinkyCloud; }

    }


    void FixedUpdate()
    {
        if (!canceled)
        {
            if (!stinkyCloud)
            {
                if (leftTap)
                {
                    rb.velocity = transform.TransformDirection(new Vector3(movementSpeed * (-1), 0, movementSpeed));

                    rb.AddRelativeForce(Vector3.forward * forwardSpeed, ForceMode.VelocityChange);

                    ship.localRotation = Quaternion.Euler(Mathf.Clamp(rotateSpeed, -90, -135), 90, 90);

                    //RotatingLeft();

                    //DOTWEEN
                    //ship.DOLocalRotate(new Vector3(-135, 90, 90), 0.5f);
                }


                if (rightTap)
                {
                    rb.velocity = transform.TransformDirection(new Vector3(movementSpeed, 0, movementSpeed));

                    rb.AddRelativeForce(Vector3.forward * forwardSpeed, ForceMode.VelocityChange);

                    ship.localRotation = Quaternion.Euler(Mathf.Clamp(rotateSpeed * (-1), -90, -45), 90, 90);

                    //RotatingRight();

                    //DOTWEEN
                    //ship.DOLocalRotate(new Vector3(-45, 90, 90), 0.5f);
                }
            }
            else
            {
                if (rightTap)
                {
                    rb.velocity = transform.TransformDirection(new Vector3(movementSpeed * (-1), 0, movementSpeed));

                    rb.AddRelativeForce(Vector3.forward * forwardSpeed, ForceMode.VelocityChange);

                    ship.localRotation = Quaternion.Euler(Mathf.Clamp(rotateSpeed, -90, -135), 90, 90);

                    //RotatingRight();

                    //DOTWEEN
                    //ship.DOLocalRotate(new Vector3(-135, 90, 90), 0.5f);
                }


                if (leftTap)
                {
                    rb.velocity = transform.TransformDirection(new Vector3(movementSpeed, 0, movementSpeed));

                    rb.AddRelativeForce(Vector3.forward * forwardSpeed, ForceMode.VelocityChange);

                    ship.localRotation = Quaternion.Euler(Mathf.Clamp(rotateSpeed * (-1), -90, -45), 90, 90);

                    //RotatingLeft();

                    //DOTWEEN
                    //ship.DOLocalRotate(new Vector3(-45, 90, 90), 0.5f);
                }
            } // Stinky Cloud Active

        }

        if (canceled)
        {
            ship.localRotation = Quaternion.Euler(-90, 90, 90);
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

    void ToggleStinkyCloud()
    {
        stinkyCloud = !stinkyCloud;
    }
}
