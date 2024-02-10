using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private string _currentScene;
    [SerializeField] private GameObject _shading;
    [SerializeField] private GameObject _mainPausePanel;
    [SerializeField] private GameObject _settingsPausePanel;
    [SerializeField] private GameObject _mapPausePanel;
    [SerializeField] private GameObject _notesPausePanel;
    [SerializeField] private GameObject _handbookPausePanel;

    void Start()
    {
        _currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(_currentScene == "Main");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Time.timeScale = 0f;
            ShowMainPausePanel();
            Shading(true);
        }
    }

    public void ToContinueGame()
    {
        if (_currentScene == "Menu")
        {
            SceneManager.LoadScene("Main");
        }
        else if (_currentScene == "Main")
        {
            Time.timeScale = 1f;
            HideMainPausePanel();
            Shading(false);
        }
    }

    public void ToExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        
    }

    public void ShowMainPausePanel()
    {
        _mainPausePanel.SetActive(true);
    }

    private void Shading(bool activeStatus)
    {
        _shading.SetActive(activeStatus);
    }

    private void ShowSettingsPausePanel()
    {
    }

    private void ShowMapPausePanel()
    {
    }

    private void ShowNotesPausePanel()
    {
    }

    private void ShowHandbookPausePanel()
    {        
    }

    private void HideMainPausePanel()
    {
        _mainPausePanel.SetActive(false);
    }

    private void HideSettingsPausePanel()
    {
    }

    private void HideMapPausePanel()
    {
    }

    private void HideNotesPausePanel()
    {
    }

    private void HideHandbookPausePanel()
    {        
    }
}
