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

       

        //if(Controller.isGrounded == false) 
        {
            verticalVelocity += 3.0f * Physics.gravity.y * Time.deltaTime;
        }

          
        
    }

    public void Jump(float jumpForce)
    {
      //  Do a raycast check straight down to see if we are low enough to jump
       // if(Controller.isGrounded)
        {
            verticalVelocity = jumpForce;
        }
    }
}
