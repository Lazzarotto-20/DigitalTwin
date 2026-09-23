using Unity.VisualScripting;
using UnityEngine;

public class ComponentInteractable : MonoBehaviour
{
    [Header("Component ID")]
    public string componentName = "Main Valve";

    [Header("Equipement Telemetry")]
    public float temperature = 45.0f;
    public float pressure = 1.2f;
    public bool isOperational = true;

    // Function called upon selection.
    public void SelectComponent()
    {
        Debug.Log($"[Digital Twin] Selected Component: {componentName} | Temp: {temperature}°C");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
