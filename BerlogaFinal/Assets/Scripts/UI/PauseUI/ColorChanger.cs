using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    private ButtonColorController _buttonColorController;

    [SerializeField] private Button[] _headButtons;

    private void NormalizeAllButtons(Button[] buttons)
    {
        foreach (var button in buttons)
        {
            _buttonColorController.MakeHeadButtonIsUsual();
        }
    }
}
