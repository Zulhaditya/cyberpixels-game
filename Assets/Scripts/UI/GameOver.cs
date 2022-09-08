using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenu;

    // Variable bool untuk pause game
    public static bool isGamePaused = false;

    [SerializeField] GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    // Fungsi untuk pause game, timescale fungsinya untuk menghentikan seluruh pergerakan objek
    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    private void OnEnable()
    {
        Health.OnPlayerDeath += EnabledGameOverMenu;
        PlayerMovement.OnPlayerFall += EnabledGameOverMenu;
    }

    private void OnDisable()
    {
        Health.OnPlayerDeath -= EnabledGameOverMenu;
        PlayerMovement.OnPlayerFall -= EnabledGameOverMenu;
    }

    public void EnabledGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        PlayerPrefs.SetFloat("CurrentScore", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Keluar dari game");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
