using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossaryStatusScript : MonoBehaviour
{
    [SerializeField] private GameObject glossaryPanel;

    private bool _isOn = false;

    void Update()
    {
        Debug.Log("fafaaf");
        if (Input.GetKeyDown(KeyCode.Y))
            if (_isOn)
            {
                HideGlossary();
                _isOn = false;
            }
            else
            {
                ShowGlossary();
                _isOn = true;
            }
    }

    private void HideGlossary()
    {
        {
            Time.timeScale = 1f;
            glossaryPanel.SetActive(false);
        }
    }

    private void ShowGlossary()
    {
        Time.timeScale = 0f;
        glossaryPanel.SetActive(true);
    }
}
