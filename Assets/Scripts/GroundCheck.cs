using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private float groundingRaycastDistance = 8f;
    public float fallSpeed = 5f;
    public event Action OnDie;
    AudioState audioState;
    bool soundRunning;
    bool fallSound;
    InputReader inputReader;
    int previousGroundCheck = -1;

    private void Start()
    {
        audioState = GetComponent<AudioState>();
        soundRunning = false;
        fallSound = false;
        inputReader = GetComponent<InputReader>();
    }

    void Update()
    {
        int groundCheck = IsGrounded();
        if(groundCheck == previousGroundCheck)
        {
            return;
        }

        previousGroundCheck = groundCheck;

        if(groundCheck == 1)
        {
            PlayerStateMachine psm = GetComponent<PlayerStateMachine>();
            psm.SwitchState(new PlayerFreeLookState(psm));
        }

        else if (groundCheck == 0 && !inputReader.GetJump() == true)
        {
            if (!fallSound)
            {
                fallSound = true;
                audioState.ManFearFallingSound();
            }

            MoveDownward();
        }

       
    }

    void MoveDownward()
    {
        transform.Translate(Vector3.down * fallSpeed );
    }

    public int IsGrounded()
    {

        RaycastHit raycast;
        if (Physics.SphereCast(transform.position,5f, Vector3.down, out raycast))
        {
            if(Vector3.Distance(transform.position, raycast.point) < groundingRaycastDistance)
            {
                if (raycast.collider.gameObject.CompareTag("Floor"))
                {
                    Debug.Log("floor detected");
                    OnDie?.Invoke();
                    if (!soundRunning)
                    {
                        soundRunning = true;
                        audioState.BodyHitGround();
                    }

                    return 2; //Kill Floor

                }





                return 1; // safe landing
            }
        }

        return 0; // still falling
    }



 
}
