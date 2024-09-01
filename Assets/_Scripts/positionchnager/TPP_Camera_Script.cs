using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPP_Camera_Script : MonoBehaviour
{
    public Transform target; // The target the camera should follow (e.g., the player)
    public float distance ; // Default distance from the target
    public float height ; // Default height above the target
    public float rotationSpeed; // Rotation speed based on mouse input
    public float collisionOffset; // Offset to prevent camera clipping at the collision point
    public LayerMask collisionLayers; // Layers the camera should collide with

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    void LateUpdate()
    {
        // Get mouse inputs
        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        currentY = Mathf.Clamp(currentY, -20f, 80f); // Limit vertical rotation

        // Calculate the desired position for the camera
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 direction = new Vector3(0, 0, -distance);
        Vector3 desiredPosition = target.position + rotation * direction + Vector3.up * height;

        // Perform a raycast from the target to the desired camera position
        RaycastHit hit;
        if (Physics.Raycast(target.position + Vector3.up * height, desiredPosition - (target.position + Vector3.up * height), out hit, distance, collisionLayers))
        {
            // If there is a collision, adjust the camera position to the hit point with an offset
            transform.position = hit.point + hit.normal * collisionOffset;
        }
        else
        {
            // If no collision, use the desired position
            transform.position = desiredPosition;
        }

        // Set the camera to look at the target
        transform.LookAt(target.position + Vector3.up * height);
    }
}
