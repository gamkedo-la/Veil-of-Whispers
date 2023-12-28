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
    public float camBehind = 25f;
    public float camAbove = 5f;
    public float camLookAhead = 30f;
    public Vector3 rightDistance;
    public Vector3 leftDistance;



    private void Start()
    {
        cam = Camera.main;
        layerMask = ~LayerMask.GetMask("Player", "Enemy");
    }

    private void LateUpdate()
    {
       
        Vector3 camOffset = -player.transform.forward * camBehind + Vector3.up * camAbove;
        cam.transform.position = player.transform.position + camOffset;
        Vector3 playerToCam = cam.transform.position - player.transform.position;
        bool raycastHit = Physics.Raycast(player.transform.position, playerToCam, out hit, camOffset.magnitude, layerMask);
        cam.transform.LookAt(player.transform.position + player.transform.forward * camLookAhead);


        if (raycastHit && cam.gameObject.transform.rotation.y > 100)

        {
            cam.transform.position = hit.point + rightDistance * 0.5f;
        }

        if(raycastHit && cam.gameObject.transform.rotation.y < 100)
        {
            cam.transform.position = hit.point + leftDistance * 0.5f;
        }



    }

}
