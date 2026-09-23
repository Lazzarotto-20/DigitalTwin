using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    // Focused object by the camera.
    public Transform target;
    // Camera's speed.
    public float cameraSpeed = 5.0f;
    // The distance the camera must keep from the object not to touch it.
    public Vector3 distance = new Vector3(0, 1.5f, -3f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Only moves if a target is selected.
        if(target != null)
        {
            // Calculates
            Vector3 desiredPosition = target.position + distance;

            transform.position = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed * Time.deltaTime);

            transform.LookAt(target);
        }
    }

    public void DefineTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
