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

    /// Registra una decisi�n tomada por el usuario.
    public void RegisterDecision(int decisionID)
    {
        if (!decisions.Contains(decisionID))
        {
            decisions.Add(decisionID);
            Debug.Log("Decisi�n registrada: " + decisionID);
        }
    }

    /// Eval�a si una vi�eta puede desbloquearse.
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

    /// Limpia todas las decisiones registradas (útil al reiniciar la partida).
    public void ReiniciarDecisiones()
    {
        decisions.Clear();
        Debug.Log("DecisionSystem: decisiones reiniciadas.");
    }
}