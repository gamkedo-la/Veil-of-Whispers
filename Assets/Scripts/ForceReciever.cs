using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReciever : MonoBehaviour
{
    private float verticalVelocity;
    private float gravity = 9.81f; 

    [SerializeField] private CharacterController Controller;

    public Vector3 Movement => Vector3.up * verticalVelocity;

    private void Update()
    {

        if (verticalVelocity < 0f && Controller.isGrounded)
        {
            verticalVelocity = -gravity * 0.25f;

        }

        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

          
        
    }

    public void Jump(float jumpForce)
    {
        Time.timeScale = 0.8f;
        verticalVelocity += jumpForce;
    }
}
