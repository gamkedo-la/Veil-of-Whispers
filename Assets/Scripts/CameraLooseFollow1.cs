using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLooseFollow1 : MonoBehaviour
{
    Camera cam;
    public Transform player;
    public  Vector3 distanceOffset;
    public float maxOffsetDistance = 18f;
    public float minOffsetDistance = -18f;
    public float smoothTime = 0.5f;
    Vector3 camDistance;
    RaycastHit hit;
    int layerMask;

    
    private void Start()
    {
        cam = Camera.main;
        layerMask = ~LayerMask.GetMask(LayerMask.LayerToName(player.gameObject.layer));
        camDistance = this.transform.position - cam.transform.position;

    }

    private void Update()
    {
        cam.transform.LookAt(player);
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity,layerMask))
        {
            float distanceFromHitPoint = Vector3.Distance(hit.point, player.position);
            
        }

        else
        {
        }

    }

    

    private void LateUpdate()
    {
        cam.transform.position = this.transform.position + camDistance - distanceOffset;
    }

}
