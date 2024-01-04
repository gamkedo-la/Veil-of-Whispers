using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour,PlayerInput.IPlayerActions
{
    public Vector2 MovementValue { get; private set; }
    public Vector2 LookValue { get; private set; }
    public bool isAttacking { get; private set; }
    public bool isCrouch { get; private set; }
    public bool isGamePaused { get; private set; }

    public Animator animator;
    public event Action TargetEvent;
    public event Action CancelEvent;
    public event Action JumpEvent;



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

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed) { isAttacking = true; }

        else if(context.canceled)
        {
            isAttacking = false;
        }

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        JumpEvent?.Invoke();

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
}
