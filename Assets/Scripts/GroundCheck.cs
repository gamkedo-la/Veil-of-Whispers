using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float groundingRaycastDistance = 0.2f;



    private void Update()
    {
        if (!IsGrounded())
        {
            Debug.Log("Character is falling");
        }
        else
        {
            Debug.Log("Character is not falling");
        }
    }


    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundingRaycastDistance);

        if (hit.collider != null)
        {
            Debug.Log("Character is grounded");
            return true;
        }
        else
        {
            Debug.Log("Character is not grounded");
            return false;
        }
    }
}
