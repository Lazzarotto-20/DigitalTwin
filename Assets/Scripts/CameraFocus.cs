using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    // Focused object by the camera.
    public Transform target;
    // Camera's speed.
    public float cameraSpeed = 5.0f;
    // The distance the camera must keep from the object not to touch it.
    public Vector3 distance = new Vector3(0, 1.5f, -3f);

    // New variables to remember the origin point.
    private Vector3 initialPosition;
    private Quaternion initialRotation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Only moves if a target is selected.
        if(target != null)
        {
            // Calculates the camera's final position.
            Vector3 desiredPosition = target.position + distance;
            // Moves the camera smoothly from its current position to the desired one using Lerp
            transform.position = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed * Time.deltaTime);

            // Rotates smoothly to the object
            Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, cameraSpeed * Time.deltaTime);
        }
        else
        {
            // If there is no target (target == null), it goes back to base.
            transform.position = Vector3.Lerp(transform.position, initialPosition, cameraSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, cameraSpeed * Time.deltaTime);
        }
    }

    // Called function when the mouse cliks an asset
    public void DefineTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void CleanTarget()
    {
        target = null;
    }
}
