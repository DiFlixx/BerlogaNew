using UnityEngine;

public class ShowText : MonoBehaviour
{
    [SerializeField] private GameObject[] _texts;

    public void ActivateText(int indexOfText)
    {
        HideAllTexts(_texts);
        _texts[indexOfText].SetActive(true);
    }

    private void HideAllTexts(GameObject[] _texts)
    {
        for (int i = 0; i < _texts.Length; i++)
        {
            _texts[i].SetActive(false);
        }
    }
}
