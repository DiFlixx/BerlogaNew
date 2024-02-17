using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void ContinueGame() => SceneManager.LoadScene("Main");

    public void OpenSettings(){}

    public void StartNewGame(){}

    public void ExitGame() => Application.Quit();
}
