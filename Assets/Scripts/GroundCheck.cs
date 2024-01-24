using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private float groundingRaycastDistance = 8f;
    public event Action OnDie;




    private void Update()
    {
        if (!IsGrounded())
        {
            // Free Look State
        }
       
    }


    bool IsGrounded()
    {

        RaycastHit raycast;
        if (Physics.Raycast(transform.position, Vector3.down, out raycast))
        {
            if(Vector3.Distance(transform.position, raycast.point) < groundingRaycastDistance)
            {
                
                if (raycast.collider.gameObject.CompareTag("Floor"))
                {
                    OnDie?.Invoke();
                }
                return true;
            }
        }
        
        return false;

    }
}
