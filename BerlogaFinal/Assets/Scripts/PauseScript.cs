using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseScript : MonoBehaviour
{
    public UnityEngine.GameObject PausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Time.timeScale = 0f;
            ShowPausePanel();
        }
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        HidePausePanel();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void ExitGame() => Application.Quit();

    private void ShowPausePanel() => PausePanel.SetActive(true);

    private void HidePausePanel() => PausePanel.SetActive(false);
}