using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject settings;
    public void ContinueGame() => SceneManager.LoadScene("Main");

    public void SettingsController(bool status) => settings.SetActive(status);

    public void StartNewGame(){}

    public void ExitGame() => Application.Quit();
}
