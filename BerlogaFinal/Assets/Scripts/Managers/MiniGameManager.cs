using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiniGameManager : MonoBehaviour
{

    private bool isPlayed = false;

    public void MiniGame()
    {
        if (!isPlayed)
        {
            isPlayed = true;
        } 
    }
}
