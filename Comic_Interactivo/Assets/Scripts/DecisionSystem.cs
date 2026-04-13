using System.Collections.Generic;
using UnityEngine;

/// Gestiona las decisiones del jugador y sus efectos.
public class DecisionSystem : MonoBehaviour
{
    public static DecisionSystem Instance;

    // Lista de decisiones tomadas
    private List<int> decisions = new List<int>();

    private void Awake()
    {
        Instance = this;
    }

    /// Registra una decisión tomada por el usuario.
    public void RegisterDecision(int decisionID)
    {
        if (!decisions.Contains(decisionID))
        {
            decisions.Add(decisionID);
            Debug.Log("Decisión registrada: " + decisionID);
        }
    }

    /// Evalúa si una viñeta puede desbloquearse.
    public bool CheckUnlockConditions(List<int> requiredDecisions)
    {
        foreach (int decision in requiredDecisions)
        {
            if (!decisions.Contains(decision))
                return false;
        }

        return true;
    }
    /// Permite escalar: guardar decisiones.
    public List<int> GetDecisions()
    {
        return decisions;
    }
}