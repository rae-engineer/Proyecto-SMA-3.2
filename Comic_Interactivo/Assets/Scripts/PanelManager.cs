using UnityEngine;
using System.Collections.Generic;

/// Controla qué viñetas se muestran según decisiones.
public class PanelManager : MonoBehaviour
{
    [System.Serializable]
    public class Panel
    {
        public int panelID;
        public GameObject panelObject;

        // Decisiones necesarias para desbloquear
        public List<int> requiredDecisions;
    }

    public List<Panel> panels;

    /// Muestra una viñeta si cumple condiciones.
    public void ShowPanel(int panelID)
    {
        Panel panel = panels.Find(p => p.panelID == panelID);

        if (panel == null) return;

        bool canShow = DecisionSystem.Instance.CheckUnlockConditions(panel.requiredDecisions);

        panel.panelObject.SetActive(canShow);
    }

    /// Oculta una viñeta.

    public void HidePanel(int panelID)
    {
        Panel panel = panels.Find(p => p.panelID == panelID);

        if (panel != null)
            panel.panelObject.SetActive(false);
    }

    /// Actualiza todas las viñetas.
    public void RefreshPanels()
    {
        foreach (var panel in panels)
        {
            bool unlocked = DecisionSystem.Instance.CheckUnlockConditions(panel.requiredDecisions);
            panel.panelObject.SetActive(unlocked);
        }
    }
}