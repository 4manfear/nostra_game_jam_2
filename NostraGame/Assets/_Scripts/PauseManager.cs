using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel; // Reference to the Pause Panel
    private bool isPaused = false;

    void Start()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false); // Ensure the pause panel is inactive at the start
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Freeze game time
        if (pausePanel != null)
            pausePanel.SetActive(true); // Show the pause panel
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Resume game time
        if (pausePanel != null)
            pausePanel.SetActive(false); // Hide the pause panel
    }
}
