using UnityEngine;
using TMPro; 
using UnityEngine.UI; 
using UnityEngine.Events;

public class TutorialTrigger : MonoBehaviour
{
    
    public GameObject tutorialPanel;
    public TextMeshProUGUI titleUI; 
    public Image imageUI; 



    
    public string titleText;
    public Sprite tutorialSprite;
    public UnityEvent onGotItPressed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            titleUI.text = titleText;
            imageUI.sprite = tutorialSprite;

            Button btn = tutorialPanel.GetComponentInChildren<Button>();
            if (btn != null)
            {
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(CloseTutorial);
            }

            tutorialPanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void CloseTutorial()
    {
        if (tutorialPanel == null || !tutorialPanel.activeSelf) return;

        tutorialPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (onGotItPressed != null)
        {
            onGotItPressed.Invoke();
        }

        
        Destroy(gameObject, 0.1f);
    }
}