using System.ComponentModel;
using TMPro; // Library to manipulate texts of TextMeshPro
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Interface Text Elements")]
    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtTelemetry;
    public TextMeshProUGUI txtStatus;

    [Header("Main Panel")]
    public GameObject infoPanel;

    private ComponentInteractable currentComponent; // Stores the part currently selected.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Hides the panel when the game is lauched to the moment something is clicked
        HidePanel();
    }

    public void ShowInformations(ComponentInteractable component)
    {
        currentComponent = component; // Guards the part in memory.
        infoPanel.SetActive(true); // activate the panel's visualization
    }

    public void HidePanel()
    {
        currentComponent = null;
        infoPanel.SetActive(false); // Turns off the panel's visualization
    }

    // Update is called once per frame
    void Update()
    {
        if (currentComponent != null)
        {
            txtName.text = currentComponent.componentName; ;
            txtTelemetry.text = $"Temp: {currentComponent.currentTemperature:F1}°C\nPression: {currentComponent.currentPressure:F1} bar";

            if (currentComponent.isOperational)
            {
                txtStatus.text = "Status: OPERATIONAL";
                txtStatus.color = Color.green;
            }
            else
            {
                txtStatus.text = "Status: FAILURE DETECTED";
                txtStatus.color = Color.red;
            }
        }
    }
}
