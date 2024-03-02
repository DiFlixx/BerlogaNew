using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorController : MonoBehaviour
{
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
    }

    void OnMouseDown()
    {
    }
}
