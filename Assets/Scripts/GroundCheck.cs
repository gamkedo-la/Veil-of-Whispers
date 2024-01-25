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


    private void Start()
    {
        audioState = GetComponent<AudioState>();
        soundRunning = false;
        fallSound = false;
        inputReader = GetComponent<InputReader>();
    }

    void Update()
    {
        if (!IsGrounded() && inputReader.GetJump() == false)
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

    public bool IsGrounded()
    {

        RaycastHit raycast;
        if (Physics.SphereCast(transform.position,5f, Vector3.down, out raycast))
        {
            if(Vector3.Distance(transform.position, raycast.point) < groundingRaycastDistance)
            {
                if (raycast.collider.gameObject.CompareTag("Floor"))
                {
                    if(!soundRunning)
                    {
                        soundRunning = true;
                        audioState.BodyHitGround();
                        OnDie?.Invoke();
                    }
                }

                return true;
            }
        }

        return false;
    }



 
}
