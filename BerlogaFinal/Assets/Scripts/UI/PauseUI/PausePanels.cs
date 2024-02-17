using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class PausePanels : MonoBehaviour
{
    [SerializeField] private GameObject _shading;

    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _mapPanel;
    [SerializeField] private GameObject _notesPanel;
    [SerializeField] private GameObject _guidePanel;

    public void ShadingStatus(bool activeStatus) => _shading.SetActive(activeStatus);

    public void MainPanelStatus(bool activeStatus) => _mainPanel.SetActive(activeStatus);
    public void SettingsPanelStatus(bool activeStatus) => _settingsPanel.SetActive(activeStatus);
    public void MapPanelStatus(bool activeStatus) => _mapPanel.SetActive(activeStatus);
    public void NotesPanelStatus(bool activeStatus) => _notesPanel.SetActive(activeStatus);
    public void GuidePanelStatus(bool activeStatus) => _guidePanel.SetActive(activeStatus);
}
