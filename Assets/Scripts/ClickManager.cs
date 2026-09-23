using UnityEngine;

public class ClickManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
                }
                  
            }
        }
    }
}
