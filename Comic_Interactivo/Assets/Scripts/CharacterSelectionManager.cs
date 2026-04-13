using UnityEngine;
using UnityEngine.SceneManagement;

/// Gestiona la selección del personaje en la pantalla inicial.
/// Persiste la elección para ser usada en otras escenas.
public class CharacterSelectionManager : MonoBehaviour
{
    public static CharacterSelectionManager Instance;

    private const string CHARACTER_KEY = "SELECTED_CHARACTER";

    // ID del personaje seleccionado (ej: "Mariana", "Andres")
    private string selectedCharacterID = "";

    private void Awake()
    {
        // Singleton simple para acceso global
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// Se llama desde los botones UI al seleccionar personaje.
    public void SelectCharacter(string characterID)
    {
        selectedCharacterID = characterID;
        SaveSelection();
    }

    /// Guarda la selección usando PlayerPrefs.
    /// Escalable a JSON/DB si el proyecto crece.
    private void SaveSelection()
    {
        PlayerPrefs.SetString(CHARACTER_KEY, selectedCharacterID);
        PlayerPrefs.Save();
    }

    /// Obtiene el personaje seleccionado.
    public string GetSelectedCharacter()
    {
        return PlayerPrefs.GetString(CHARACTER_KEY, "");
    }

    /// Valida que el usuario haya seleccionado personaje antes de continuar.
    public void StartComic(string sceneName)
    {
        if (string.IsNullOrEmpty(GetSelectedCharacter()))
        {
            Debug.LogWarning("Debes seleccionar un personaje antes de continuar.");
            return;
        }

        SceneManager.LoadScene(sceneName);
    }
}