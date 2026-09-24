using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private UIManager uiManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Finds the UIManager script associated to the Canvas
        uiManager = FindFirstObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Verify if user has clicked with left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Creates a ray that leaves the camera in the direction of the mouse's cursor
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits an object with Collider...
            if (Physics.Raycast(ray, out hit))
            {
                // It tries finding the script "ComponentInteractible" in the hit object
                ComponentInteractable component = hit.collider.GetComponent<ComponentInteractable>();

                // If the object has our script, the action is executed!
                if (component != null)
                {
                    component.SelectComponent();
                    Camera.main.GetComponent<CameraFocus>().DefineTarget(hit.transform);

                    // Exibits the panel with the cliked component's information.
                    if (uiManager != null) uiManager.ShowInformations(component);
                }
                else
                {
                    // If it hits an object that is not part of the motor.
                    Camera.main.GetComponent<CameraFocus>().CleanTarget();
                    if (uiManager != null) uiManager.HidePanel();
                }
            }
            else
            {
                // It it doesn't hit anything (void)
                Camera.main.GetComponent<CameraFocus>().CleanTarget();
                if (uiManager != null) uiManager.HidePanel();
            }
        }
    }
}
