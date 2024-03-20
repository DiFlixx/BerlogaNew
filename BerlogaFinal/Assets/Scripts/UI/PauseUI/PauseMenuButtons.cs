using UnityEngine;

public class PauseMenuButtons : MonoBehaviour
{
    public PausePanelController pausePanelController;
    [SerializeField] private UnityEngine.GameObject _shading;
    [SerializeField] private AudioSource buttonSound;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Time.timeScale = 0f;
            _shading.SetActive(true);
            pausePanelController.ActivatePanel(0);
        }
    }

    public void ToContinueGame()
    {
        Time.timeScale = 1f;
        _shading.SetActive(false);
        pausePanelController.HideMenuPanel();
    }

    public void MoveToSettingsPanel()
    {
        pausePanelController.ActivatePanel(1);
        buttonSound.Play();
    }

    public void BackToMainPanel()
    {
        pausePanelController.ActivatePanel(0);
        buttonSound.Play();
    }

    public void ToExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
