using UnityEngine;
using UnityEngine.UI;

public class ButtonColorController : MonoBehaviour
{
    private Button _button;
    private ColorBlock _theColor;
    private static Button _currentMainButton;

    public bool isMenuButton;

    void Update()
    {
    }

    void Start()
    {
        if (isMenuButton)
        {
            GettingComponent();
            MakeHeadButtonIsMain();
        }
        else
        {
            GettingComponent();
        }
    }
    
    private void GettingComponent()
    {
        _button = GetComponent<Button>();
        _theColor = _button.GetComponent<Button>().colors;
        
    }

    public void MakeHeadButtonIsMain()
    {
        //MakeHeadButtonIsUsual();       
        _theColor.normalColor = new Color32(93, 15, 95, 255);
        _button.colors = _theColor;
        _currentMainButton = _button;
    }

    public void MakeHeadButtonIsUsual()
    {
        _theColor.normalColor = new Color32(93, 15, 95, 0);
        _currentMainButton.colors = _theColor;
    }
}