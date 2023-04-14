using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenManager : MonoBehaviour
{
    public GameObject PauseScreen;

    public void Start(){
        PauseScreen.SetActive(false);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            PauseScreen.SetActive(!PauseScreen.activeSelf);
    }
}