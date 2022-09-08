using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    public GameObject pausedMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //SceneManager.LoadScene(1);
            pausedMenu.SetActive(true);
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerShoot>().enabled = false;
        }
    }
}
