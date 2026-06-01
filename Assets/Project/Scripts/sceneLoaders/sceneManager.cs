using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour
{
    [Header("Scene Names")]
    [SerializeField] private string introSceneName = "intro";
    [SerializeField] private string level1SceneName = "Level1";
    [SerializeField] private string cutsceneLevel1SceneName = "CutsceneLevel1";
    [SerializeField] private string level2SceneName = "Level2";

    [Header("Menu Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject controlsPanel;

    public void Play()
    {
        LoadIntro();
    }

    public void OpenSettings()
    {
        ShowOnlyPanel(settingsPanel);
    }

    public void OpenControls()
    {
        ShowOnlyPanel(controlsPanel);
    }

    public void BackToMainMenu()
    {
        ShowOnlyPanel(mainMenuPanel);
    }

    private void ShowOnlyPanel(GameObject panelToShow)
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        if (controlsPanel != null)
            controlsPanel.SetActive(false);

        if (panelToShow != null)
            panelToShow.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Quit button clicked.");
        Application.Quit();
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene(introSceneName);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(level1SceneName);
    }

    public void LoadCutsceneLevel1()
    {
        SceneManager.LoadScene(cutsceneLevel1SceneName);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(level2SceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadLevel2();
        }
    }
}