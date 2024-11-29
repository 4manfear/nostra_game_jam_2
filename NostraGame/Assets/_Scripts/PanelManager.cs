using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel; // Reference to the Pause Panel
    [SerializeField] private GameObject[] otherPanels; // References to other panels
    private bool isPaused = false;

    void Start()
    {
        // Ensure all panels except the pause panel are inactive
        if (pausePanel != null)
            pausePanel.SetActive(false);

        foreach (var panel in otherPanels)
        {
            if (panel != null)
                panel.SetActive(false);
        }
    }

    public void TogglePausePanel()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            ActivatePanel(pausePanel); // Activate the pause panel
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            DeactivateAllPanels(); // Deactivate all panels
            Time.timeScale = 1f; // Resume the game
        }
    }

    public void ShowPanel(GameObject panelToShow)
    {
        if (panelToShow != null)
        {
            DeactivateAllPanels(); // Deactivate all panels first
            panelToShow.SetActive(true); // Show the specified panel
        }
    }

    private void ActivatePanel(GameObject panel)
    {
        if (panel != null)
            panel.SetActive(true);
    }

    private void DeactivateAllPanels()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);

        foreach (var panel in otherPanels)
        {
            if (panel != null)
                panel.SetActive(false);
        }
    }
}
