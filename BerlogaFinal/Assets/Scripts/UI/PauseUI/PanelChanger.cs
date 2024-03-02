using UnityEngine;

public class PanelChanger : MonoBehaviour
{
    [SerializeField] private PausePanelController pausePanelController;
    [SerializeField] private AudioSource soundEffect;

    public void ChangePanel(int panelIndex)
    {
        soundEffect.Play();
        pausePanelController.ActivatePanel(panelIndex);
    }
}
