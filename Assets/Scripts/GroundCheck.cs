using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private float groundingRaycastDistance = 8f;



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

        RaycastHit raycast;
        if (Physics.Raycast(transform.position, Vector3.down, out raycast))
        {
            if(Vector3.Distance(transform.position, raycast.point) < groundingRaycastDistance)
            {
                return true;
            }
        }
        
        return false;

    }
}
