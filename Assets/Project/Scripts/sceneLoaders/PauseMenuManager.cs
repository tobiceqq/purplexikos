using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject pauseMenu;
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject controlsPanel;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                OpenPauseMenu();
            }
            else
            {
                HandleEscapeInsideMenu();
            }
        }
    }

    void OpenPauseMenu()
    {
        isPaused = true;

        pauseMenu.SetActive(true);

        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        controlsPanel.SetActive(false);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        isPaused = false;

        pauseMenu.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OpenSettings()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void OpenControls()
    {
        mainPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void BackToPause()
    {
        settingsPanel.SetActive(false);
        controlsPanel.SetActive(false);

        mainPanel.SetActive(true);
    }

    void HandleEscapeInsideMenu()
    {
        if (settingsPanel.activeSelf)
        {
            BackToPause();
            return;
        }

        if (controlsPanel.activeSelf)
        {
            BackToPause();
            return;
        }

        ResumeGame();
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}