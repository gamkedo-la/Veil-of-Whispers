using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLooseFollow : MonoBehaviour
{
    public Transform focusLocation;
    private Camera chaseCamera;
    private float distanceSinceLastCameraMove = 0.0f;
    private float movedBodyEnoughToMoveCameraThreshold = 15.0f;
    private Vector3 previousFocusLocation;

    // Start is called before the first frame update
    void Start()
    {
        chaseCamera = Camera.main;
        previousFocusLocation = transform.position;
    }

    private void Update()
    {
        distanceSinceLastCameraMove = Vector3.Distance(previousFocusLocation,
                            focusLocation.position);
        if(distanceSinceLastCameraMove > movedBodyEnoughToMoveCameraThreshold)
        {
            previousFocusLocation = focusLocation.position;
        }
        Debug.Log(distanceSinceLastCameraMove);
    }

    private void FixedUpdate()
    {
        float fitTuningNumber = 0.04f;
        chaseCamera.transform.position = Vector3.Lerp(chaseCamera.transform.position, transform.position, fitTuningNumber);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        chaseCamera.transform.LookAt(focusLocation);
    }
}
