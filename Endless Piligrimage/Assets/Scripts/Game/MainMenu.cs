using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Journey");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
        PlayerManager.numberOfCoins = 0;
        SceneManager.LoadScene("Menu");
    }
}
