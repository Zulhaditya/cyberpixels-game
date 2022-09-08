using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Invoke("GameCompleted", 2f);
        }
    }

    private void GameCompleted()
    {
        SceneManager.LoadScene("FinishMenu");
    }
}
