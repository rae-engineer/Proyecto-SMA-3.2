using UnityEngine;
using UnityEngine.UI;

public class FavoritoManager : MonoBehaviour
{
    public Button btnFavorito;
    public string viñetaID = "viñeta_001"; // cambia este ID por cada viñeta

    private bool esFavorito = false;

    void Start()
    {
        // Revisar si ya estaba guardada
        esFavorito = PlayerPrefs.GetInt("fav_" + viñetaID, 0) == 1;
        btnFavorito.onClick.AddListener(ToggleFavorito);
        ActualizarTexto();
    }

    void ToggleFavorito()
    {
        esFavorito = !esFavorito;

        if (esFavorito)
            PlayerPrefs.SetInt("fav_" + viñetaID, 1);
        else
            PlayerPrefs.DeleteKey("fav_" + viñetaID);

        PlayerPrefs.Save();
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        // Cambia el texto del botón según el estado
        btnFavorito.GetComponentInChildren<TMPro.TextMeshProUGUI>().text =
            esFavorito ? "❤️ Guardado" : "🤍 Añadir a Favoritos";
    }
}