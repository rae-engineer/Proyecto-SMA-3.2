using UnityEngine;
using UnityEngine.UI;

public class FavoriteButton : MonoBehaviour
{
    public string panelId;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        bool added = FavoritesManager.Instance.Toggle(panelId);
        Debug.Log(added ? "Agregado a favoritas: " + panelId : "Eliminado: " + panelId);
    }
}