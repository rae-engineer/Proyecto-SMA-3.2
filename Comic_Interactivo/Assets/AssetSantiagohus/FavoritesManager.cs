using System.Collections.Generic;
using UnityEngine;

public class FavoritesManager : MonoBehaviour
{
    public static FavoritesManager Instance { get; private set; }
    private HashSet<string> favorites = new HashSet<string>();

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool Toggle(string id)
    {
        if (favorites.Contains(id)) favorites.Remove(id);
        else favorites.Add(id);
        return favorites.Contains(id);
    }

    public bool IsFavorite(string id) => favorites.Contains(id);
    public List<string> GetAll() => new List<string>(favorites);
}