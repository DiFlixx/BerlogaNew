using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    public PausePanels pausePanels;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Time.timeScale = 0f;
            pausePanels.ShadingStatus(true);
            pausePanels.MenuChangeButton(true);
            pausePanels.NotesChangeButton(true);
            pausePanels.MainPanelStatus(true);
        }
    }

    public void ToContinueGame()
    {
        Time.timeScale = 1f;
        pausePanels.ShadingStatus(false);
        pausePanels.MainPanelStatus(false);
        pausePanels.MenuChangeButton(false);
        pausePanels.NotesChangeButton(false);
    }

    public void MoveToSettingsPanel()
    {
        pausePanels.MainPanelStatus(false);
        pausePanels.SettingsPanelStatus(true);
        pausePanels.NotesChangeButton(false);
        pausePanels.MenuChangeButton(false);
    }

    public void BackToMainPanel()
    {
        pausePanels.SettingsPanelStatus(false);
        pausePanels.MainPanelStatus(true);
        pausePanels.MenuChangeButton(true);
        pausePanels.NotesChangeButton(true);
    }

    public void ToExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
    }
}
