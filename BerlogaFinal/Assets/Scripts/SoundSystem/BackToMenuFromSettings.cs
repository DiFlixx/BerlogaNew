using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuFromSettings : MonoBehaviour
{
    public void BackToMenu() => SceneManager.LoadScene("Menu");
}
