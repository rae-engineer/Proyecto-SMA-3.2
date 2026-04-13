using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// Muestra la introducción narrativa del personaje seleccionado.
public class CharacterIntroManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Image characterImage;

    [System.Serializable]
    public class CharacterData
    {
        public string id;
        public string characterName;
        public string description;
        public Sprite image;
    }

    [Header("Character Data")]
    public CharacterData[] characters;

    private void Start()
    {
        LoadCharacterData();
    }

    /// Carga el personaje seleccionado desde PlayerPrefs
    /// y muestra su información.
    private void LoadCharacterData()
    {
        string selectedID = PlayerPrefs.GetString("SELECTED_CHARACTER", "");

        foreach (var character in characters)
        {
            if (character.id == selectedID)
            {
                DisplayIntro(character);
                return;
            }
        }

        Debug.LogError("No se encontró el personaje seleccionado.");
    }

    /// Muestra los datos en la UI.

    private void DisplayIntro(CharacterData character)
    {
        nameText.text = character.characterName;
        descriptionText.text = character.description;
        characterImage.sprite = character.image;
    }
}