using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReciever : MonoBehaviour
{
    private float verticalVelocity;
    [SerializeField] private CharacterController Controller;

    public Vector3 Movement => Vector3.up * verticalVelocity;

    private void Update()
    {
        if (verticalVelocity < 0f && Controller.isGrounded)
        {
            verticalVelocity = 0f;
        }

        else
        {
            verticalVelocity += Physics.gravity.y + Time.deltaTime;
        }
    }

    public void Jump(float jumpForce)
    {
        verticalVelocity += jumpForce;
    }
}
