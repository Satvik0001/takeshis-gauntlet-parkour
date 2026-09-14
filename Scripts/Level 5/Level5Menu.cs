using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5Menu : MonoBehaviour
{
    public void MainMenu()
    {
        Time.timeScale = 1f; // In case the game was paused
        SceneManager.LoadScene("MainMenu");
    }
}