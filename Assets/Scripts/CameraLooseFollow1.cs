using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLooseFollow1 : MonoBehaviour
{
    Camera cam;
    public Transform player;
    RaycastHit hit;
    int layerMask;

    
    private void Start()
    {
        cam = Camera.main;
        layerMask = ~LayerMask.GetMask(LayerMask.LayerToName(player.gameObject.layer));

    }

    private void Update()
    {
       
    }


    private void LateUpdate()
    {
        float camBehind = 25f;
        float camAbove = 5f;
        float camLookAhead = 30f;
        Vector3 camOffset = -player.transform.forward * camBehind + Vector3.up * camAbove;
        cam.transform.position = player.transform.position + camOffset;
        Vector3 playerToCam = cam.transform.position - player.transform.position;
        bool raycastHit = Physics.Raycast(player.transform.position, playerToCam, out hit, camOffset.magnitude, layerMask);
        cam.transform.LookAt(player.transform.position + player.transform.forward * camLookAhead);


        if (raycastHit)

        {
            //Debug.Log(hit.collider.gameObject.name);
            cam.transform.position = hit.point + cam.transform.forward * 0.5f;// Vector3.Lerp(cam.transform.position, player.transform.position , Time.deltaTime);
        }



    }

}
