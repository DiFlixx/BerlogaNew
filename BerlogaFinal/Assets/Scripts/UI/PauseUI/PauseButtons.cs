using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    public PausePanels pausePanels;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Time.timeScale = 0f;
            pausePanels.ShadingStatus(true);
            pausePanels.MainPanelStatus(true);
        }
    }

    public void ToContinueGame()
    {
        Time.timeScale = 1f;
        pausePanels.ShadingStatus(false);
        pausePanels.MainPanelStatus(false);
    }

    public void ToExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        
    }
}
