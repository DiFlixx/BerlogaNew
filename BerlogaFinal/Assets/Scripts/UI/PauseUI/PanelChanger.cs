using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PanelChanger : MonoBehaviour
{
    [SerializeField] private PausePanels pausePanels;

    public void GoToNotesPanel()
    {
        pausePanels.MainPanelStatus(false);
        //pausePanels.GuidePanelStatus(false); потом добавить
        //pausePanels.MapPanelStatus(false); потом добавить

        pausePanels.NotesPanelStatus(true);
    }

    public void GoToMenuPanel()
    {
        pausePanels.NotesPanelStatus(false);
        //pausePanels.GuidePanelStatus(false); потом добавить
        //pausePanels.MapPanelStatus(false); потом добавить

        pausePanels.MainPanelStatus(true);
    }
}
