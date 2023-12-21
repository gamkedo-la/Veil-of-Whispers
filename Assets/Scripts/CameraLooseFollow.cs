using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLooseFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float rotationSpeed = 2.0f;
    public float distance = 5.0f;
    public float minDistance = 2.0f; // Minimum distance between the player and the camera
    public float heightOffset = 2.0f;
    public float maxUpwardRotation = 80.0f; // Maximum upward rotation angle
    public float maxDownwardRotation = 80.0f; // Maximum downward rotation angle
    private Camera chaseCamera;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    public float obstacleAvoidanceRadius = 1.0f;

    private void Start()
    {
        chaseCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Mouse.current.delta.x.ReadValue();
        float mouseY = Mouse.current.delta.y.ReadValue();

        // Adjust the vertical rotation
        rotationX -= mouseY * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, -maxDownwardRotation, maxUpwardRotation);

        // Adjust the horizontal rotation
        rotationY += mouseX * rotationSpeed;
    }

    private void LateUpdate()
    {
        // Convert vertical rotation to Quaternion
        Quaternion verticalRotation = Quaternion.Euler(rotationX, 0, 0);

        // Convert horizontal rotation to Quaternion
        Quaternion horizontalRotation = Quaternion.Euler(0, rotationY, 0);

        // Combine both rotations
        Quaternion combinedRotation = verticalRotation * horizontalRotation;

        // Calculate the desired position without obstacle avoidance
        Vector3 desiredPosition = playerTransform.position + combinedRotation * new Vector3(0, heightOffset, -distance);

        // Check for obstacles
        RaycastHit hit;
        if (Physics.Raycast(playerTransform.position, desiredPosition - playerTransform.position, out hit, distance))
        {
            // Adjust the camera position to avoid obstacles
            float newDistance = Mathf.Max(hit.distance - minDistance, minDistance);
            chaseCamera.transform.position = playerTransform.position + combinedRotation * new Vector3(0, heightOffset, -newDistance);
        }
        else
        {
            // Set the camera's position to the desired position without obstacles
            chaseCamera.transform.position = desiredPosition;
        }

        // Make the camera look at the player's position
        chaseCamera.transform.LookAt(playerTransform.position + Vector3.up * heightOffset);
    }
}
