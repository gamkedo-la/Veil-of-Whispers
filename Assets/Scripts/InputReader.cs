using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour,PlayerInput.IPlayerActions
{
    public Vector2 MovementValue { get; private set; }


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
    public void OnLook(InputAction.CallbackContext context)
    {

    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
        Debug.Log("run");
    }private PlayerInput playerInput;

    
}
