using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputReader : MonoBehaviour,PlayerInput.IPlayerActions
{
    private PlayerInput playerInput;

    public event Action moveEvent;

    private void Start()
    {
       playerInput = new PlayerInput();
       playerInput.Player.SetCallbacks(this);
       playerInput.Player.Enable();
    }
    private void OnDestroy()
    {
       playerInput.Player.Enable();
    }
    public void OnLook(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {

    }

    public void OnMovement(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        moveEvent?.Invoke();
    }
}
