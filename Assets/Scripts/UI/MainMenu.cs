using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Keluar dari game");
    }

    public void StartGame()
    {
        PlayerPrefs.SetFloat("CurrentScore", 0);
        SceneManager.LoadScene("Level1");
    }


}
