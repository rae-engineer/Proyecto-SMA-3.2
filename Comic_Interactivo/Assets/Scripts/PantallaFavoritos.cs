using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PantallaFavoritos : MonoBehaviour
{
    public GameObject panelFavoritos;
    public Button btnAbrirFavoritos;
    public Transform contenido; // el Content del ScrollView
    public GameObject prefabItem; // un Text prefab para cada viñeta

    // Lista de todas las viñetas que existen en el juego
    private string[] todasLasViñetas = { "Viñeta-EspacioCampus1", "viñeta_002", "viñeta_003" };

    void Start()
    {
        panelFavoritos.SetActive(false);
        btnAbrirFavoritos.onClick.AddListener(AbrirFavoritos);
    }

    void AbrirFavoritos()
    {
        panelFavoritos.SetActive(true);
        MostrarFavoritos();
    }

    void MostrarFavoritos()
    {
        // Limpiar lista anterior
        foreach (Transform hijo in contenido)
            Destroy(hijo.gameObject);

        // Buscar cuáles están guardadas
        bool hayFavoritos = false;

        foreach (string id in todasLasViñetas)
        {
            if (PlayerPrefs.GetInt("fav_" + id, 0) == 1)
            {
                hayFavoritos = true;
                GameObject item = Instantiate(prefabItem, contenido);
                item.GetComponent<TextMeshProUGUI>().text = "❤️ " + id;
            }
        }

        if (!hayFavoritos)
        {
            GameObject item = Instantiate(prefabItem, contenido);
            item.GetComponent<TextMeshProUGUI>().text = "No tienes favoritos aún.";
        }
    }

    public void CerrarFavoritos()
    {
        panelFavoritos.SetActive(false);
    }
}
