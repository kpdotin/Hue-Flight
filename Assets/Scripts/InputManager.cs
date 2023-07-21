using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private TouchControls playerControls;

    #region EVENTS
    public delegate void TouchStarted();
    public event TouchStarted OnTouchStarted;

    public delegate void TouchDetected(Vector2 pos);
    public event TouchDetected OnTouchDetected;

    public delegate void TouchCanceled();
    public event TouchCanceled OnTouchCanceled;

    public delegate void RightTap();
    public event RightTap OnRightTap;

    public delegate void LeftTap();
    public event LeftTap OnLeftTap;

    #endregion

    private void Awake() => playerControls = new TouchControls();
    private void OnEnable()
    {
        playerControls.Enable();
        OnTouchDetected += DetectMovement;
    }
    private void OnDisable()
    {
        playerControls.Disable();
        OnTouchDetected -= DetectMovement;
    }

    private void Start()
    {
        playerControls.Touch.Contact.started += ctx => TouchStart(ctx);
        playerControls.Touch.Contact.performed += ctx => TouchDetect(ctx);
        playerControls.Touch.Contact.canceled += ctx => TouchCancel(ctx);
    }

    void TouchStart(InputAction.CallbackContext ctx) { OnTouchStarted?.Invoke(); }
    void TouchDetect(InputAction.CallbackContext ctx){ OnTouchDetected?.Invoke(ScreenPosition()); }
    void TouchCancel(InputAction.CallbackContext ctx) { OnTouchCanceled?.Invoke(); }
    public Vector2 ScreenPosition() { return playerControls.Touch.Position.ReadValue<Vector2>(); }

    void DetectMovement(Vector2 pos)
    {
        if(pos.x < 541f) { OnLeftTap?.Invoke(); }
        if(pos.x > 540f) { OnRightTap?.Invoke(); }
    }
}
