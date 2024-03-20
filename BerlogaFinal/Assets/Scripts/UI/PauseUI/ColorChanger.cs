using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Button[] headButtons;
    private Button _button;
    private ColorBlock _theColor;

    private void NormalizeAllButtons(Button[] buttons)
    {
        for (int index = 0; index < buttons.Length; index++)
        {
            _button = headButtons[index].GetComponent<Button>();
            _theColor = _button.GetComponent<Button>().colors;
            
            _theColor.normalColor = new Color32(93, 15, 95, 0);
            _button.colors = _theColor;
        }
    }

    public void MakeAllButtonsIsUsual()
    {
        NormalizeAllButtons(headButtons);
    }
}
