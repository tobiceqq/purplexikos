using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [Header("Game Over")]
    public string gameOverSceneName = "GameOver";

    [Header("Fall Death")]
    public float fallLimitY = -10f;

    private bool isDead = false;

    private void Update()
    {
        if (!isDead && transform.position.y < fallLimitY)
        {
            Die();
        }
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameOverSceneName);
    }
}