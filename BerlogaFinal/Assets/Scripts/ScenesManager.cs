using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void LoadSceneAdditive(string name)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        async.allowSceneActivation = true;
    }

    public void SceneChange(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
