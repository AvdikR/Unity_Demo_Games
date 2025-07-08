using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Events : MonoBehaviour
{
    public GameObject gamePausedPanel;
    public Button pauseButton;

    private void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        if (PlayerManager.gameOver)
            pauseButton.interactable = false;

        if (PlayerManager.gameOver)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PlayerManager.isGamePaused)
            {
                ContinueGame();
                gamePausedPanel.SetActive(false);
            }
            else
            {
                PauseGame();
                gamePausedPanel.SetActive(true);
            }

        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("Journey");
        PlayerManager.currentHealth = 100;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void PauseGame()
    {
        if(!PlayerManager.isGamePaused && !PlayerManager.gameOver)
        {
            Time.timeScale = 0;
            PlayerManager.isGamePaused = true;
        }
    }

    public void ContinueGame()
    {
        if (PlayerManager.isGamePaused)
        {
            Time.timeScale = 1;
            PlayerManager.isGamePaused = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
