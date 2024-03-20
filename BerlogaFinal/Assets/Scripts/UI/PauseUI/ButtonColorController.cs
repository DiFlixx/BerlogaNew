using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonColorController : MonoBehaviour
{
    [SerializeField] private ColorChanger colorChanger;
    
    private Button _button;
    private ColorBlock _theColor;

    public bool isMenuButton;

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
        colorChanger.MakeAllButtonsIsUsual();
        _theColor.normalColor = new Color32(93, 15, 95, 255);
        _button.colors = _theColor;
    }
}