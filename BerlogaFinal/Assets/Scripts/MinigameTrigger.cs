using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigameTrigger : MonoBehaviour
{
    public UnityEvent MinigameTriggered;

    void Start()
    {
    }
    
    private void TriggerEvent()
    {
        MinigameTriggered?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TriggerEvent();
        }
    }
}
