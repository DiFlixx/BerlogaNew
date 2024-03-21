using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    private bool isPlayed = false;

    public void MiniGame()
    {
        if (!isPlayed)
        {
            isPlayed = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene("FireGame");
        } 
    }
}
