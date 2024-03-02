using UnityEngine;

public class PausePanelController : MonoBehaviour
{
    [SerializeField] private GameObject[] _buttonsChangers;
    [SerializeField] private GameObject[] _panels;
    [SerializeField] private GameObject _menuPanel;

    private void ButtonsChangersController(GameObject[] buttons, bool activeStatus)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(activeStatus);
        }
    }

    public void ActivatePanel(int indexOfPanel)
    {
        if (indexOfPanel == 1)
        {
            ButtonsChangersController(_buttonsChangers, false);
            HideAllPanels(_panels);
            _panels[indexOfPanel].SetActive(true);
        }
        else
        {
            ButtonsChangersController(_buttonsChangers, true);
            HideAllPanels(_panels);
            _panels[indexOfPanel].SetActive(true);
        }
    }

    private void HideAllPanels(GameObject[] panels)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
    }

    public void HideMenuPanel()
    {
        ButtonsChangersController(_buttonsChangers, false);
        _menuPanel.SetActive(false);
    }
}