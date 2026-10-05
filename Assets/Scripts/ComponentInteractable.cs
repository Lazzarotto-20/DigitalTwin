using Unity.VisualScripting;
using UnityEngine;

public class ComponentInteractable : MonoBehaviour
{
    [Header("Component ID")]
    public string componentName = "Main Valve";

    [Header("Equipement Telemetry")]
    public float baseTemperature = 45.0f;
    public float basePressure = 1.2f;

    [HideInInspector] public float currentTemperature;
    [HideInInspector] public float currentPressure;
    [HideInInspector] public bool isOperational = true;

    // Function called upon selection.
    public void SelectComponent()
    {
        Debug.Log($"[Digital Twin] Selected Component: {componentName} | Live Temp: {currentTemperature:F1}°C");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTemperature = baseTemperature;
        currentPressure = basePressure;
        }

    // Update is called once per frame
    void Update()
    {
        float tempFluctuation = (Mathf.PerlinNoise(Time.time * 0.8f, transform.position.x) - 0.5f) * 2.5f;
        float pressureFluctuation = (Mathf.PerlinNoise(Time.time * 0.5f, transform.position.y) - 0.5f) * 0.2f;

        // Updates values in real time.
        currentTemperature = baseTemperature + tempFluctuation;
        currentPressure = Mathf.Max(0.1f, basePressure + pressureFluctuation);

        isOperational = currentTemperature < (baseTemperature + 2.0f);
    }
}
