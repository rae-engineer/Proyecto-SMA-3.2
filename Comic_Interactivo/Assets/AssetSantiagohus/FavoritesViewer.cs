using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FavoritesViewer : MonoBehaviour
{
    public Transform contentParent;
    public GameObject itemPrefab;

    public void ShowFavorites()
    {
        List<string> favs = FavoritesManager.Instance.GetAll();

        foreach (string id in favs)
        {
            GameObject item = Instantiate(itemPrefab, contentParent);
            item.GetComponentInChildren<TextMeshProUGUI>().text = id;
        }
    }
}