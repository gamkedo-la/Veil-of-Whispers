using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLooseFollow1 : MonoBehaviour
{
    Camera cam;
    public Transform player;
    public  Vector3 distanceOffset;
    public float smoothTime = 0.5f;
    public Vector3 newCamPos;
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

        bool raycastHit = Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity, layerMask);

        if(raycastHit && hit.collider.gameObject != player.gameObject)

        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, player.transform.position , Time.deltaTime);
            Debug.Log("hit");
        }

    }


    private void LateUpdate()
    {
       cam.transform.position = this.transform.position + camDistance - distanceOffset;      
    }

}
