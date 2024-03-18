using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedAction : MonoBehaviour
{
    public UnityEvent DoAction;
    
    public void StartDelay(float delay)
    {
        CancelInvoke("Do");
        Invoke("Do", delay);
    }

    private void Do()
    {
        DoAction?.Invoke();
    }
}
