using UnityEngine;
using TMPro; // Library to manipulate texts of TextMeshPro

public class UIManager : MonoBehaviour
{
    [Header("Interface Text Elements")]
    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtTelemetry;
    public TextMeshProUGUI txtStatus;

    [Header("Main Panel")]
    public GameObject infoPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Hides the panel when the game is lauched to the moment something is clicked
        HidePanel();
    }

    public void ShowInformations(ComponentInteractable component)
    {
        infoPanel.SetActive(true); // activate the panel's visualization

        // Updates the texts with the script's information of the selected part
        txtName.text = component.componentName;
        txtTelemetry.text = $"Temp: {component.temperature:F1}°C\nPression: {component.pressure:F1} bar";

        if (component.isOperational)
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

    public void HidePanel()
    {
        infoPanel.SetActive(false); // Turns off the panel's visualization
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
