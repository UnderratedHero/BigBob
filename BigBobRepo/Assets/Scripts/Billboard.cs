using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera mainCamera;

    private void Start()
    {
        // Automatically locate main camera if not set in the inspector
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    private void LateUpdate()
    {
        // Calculate the direction from the object to the camera
        Vector3 direction = mainCamera.transform.position - transform.position;
        // Remove any vertical (Y) influence
        direction.y = 0;

        // Rotate the object to face the camera, but only around the Y axis
        Quaternion rotationY = Quaternion.LookRotation(direction);
        // Add a 90-degree rotation around the X axis
        Quaternion rotationX = Quaternion.Euler(90, 0, 0);

        // Combine the rotations
        transform.rotation = rotationY * rotationX;
    }
}
