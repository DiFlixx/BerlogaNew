using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorController : MonoBehaviour
{
    [SerializeField] private Button[] headButtons;

    private Button _menuButton;
    private Button _settingsButton;
    private Button _guideButton;
    private Button _mapButton;

    void Start()
    {
        _menuButton = headButtons[0].GetComponent<Button>();
        _settingsButton = headButtons[1].GetComponent<Button>();
        _guideButton = headButtons[2].GetComponent<Button>();
        _mapButton = headButtons[3].GetComponent<Button>();
    }

    private int MakeNormalColor()
    {
        return 0;
    }
}
