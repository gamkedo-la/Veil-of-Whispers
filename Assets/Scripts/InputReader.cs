using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour,PlayerInput.IPlayerActions
{
    public Vector2 MovementValue { get; private set; }
    public Vector2 LookValue { get; private set; }
    public bool isPunchR { get;  set; }
    public bool isPunchL { get;  set; }
    public bool isKickR { get;  set; }
    public bool isKickL { get;  set; }

    public bool isCrouch { get; private set; }
    public bool isGamePaused { get; private set; }

    public Animator animator;
    public event Action TargetEvent;
    public event Action CancelEvent;
    public event Action JumpEvent;
    private bool jumpCheck = false;



    private PlayerInput playerInput;



    private void Start()
    {
       playerInput = new PlayerInput();
       playerInput.Player.SetCallbacks(this);
       playerInput.Player.Enable();
       isCrouch = false;
    }
    private void OnDestroy()
    {
       playerInput.Player.Disable();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        LookValue = context.ReadValue<Vector2>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();

    }

  

    public void OnTarget(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        TargetEvent?.Invoke();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        CancelEvent?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) { jumpCheck = false; }

        else
        {
            JumpEvent?.Invoke();
            jumpCheck = true;
        }

    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed) { 

            isCrouch = true;
            Debug.Log(context);
        }

        if (context.canceled)
        {
            isCrouch = false;
            Debug.Log(context);
        }

    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!isGamePaused)
            {
                //Pause section
                GameplayUI.Instance.PauseIndicator.SetActive(true);
                Time.timeScale = 0f;
                isGamePaused = true;                                
                Debug.Log("Game Paused");
            }
            else
            {
                GameplayUI.Instance.PauseIndicator.SetActive(false);
                //Resume Section
                Time.timeScale = 1f;

                isGamePaused = false;
                Debug.Log("Game Resumed");
            }
        }
    }

    public void OnRightPunch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isPunchR = true;
        }
    }

    public void OnLeftPunch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isPunchL = true;
        }
    }

    public void OnRightKick(InputAction.CallbackContext context)
    {
        if (context.performed) {

            isKickR = true; }

      
    }

    public void OnLeftKick(InputAction.CallbackContext context)
    {
        if (context.performed) { isKickL = true; }

      
    }

    public bool GetJump()
    {
        return jumpCheck;
    }

 
}
