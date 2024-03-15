using UnityEngine;
using UnityEngine.UI;

public class ButtonColorController : MonoBehaviour
{
    private Button _button;
    private ColorBlock _theColor;
    
    public bool isMenuButton;
    
    void Start()
    {
        GettingComponent();
    }
    
    private void GettingComponent()
    {
        _button = GetComponent<Button>();
        _theColor = _button.GetComponent<Button>().colors;
    }

    public void MakeHeadButtonIsMain()
    {
        _theColor.normalColor = new Color(132, 3, 151, 255);
        _button.colors = _theColor;
    }

    /*public void MakeHeadButtonIsUsual()
    {
        _button.colors = _defaultColorParameters;
    }*/
}
