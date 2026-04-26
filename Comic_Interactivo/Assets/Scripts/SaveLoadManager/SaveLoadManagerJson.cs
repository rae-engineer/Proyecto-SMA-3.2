using System.IO;
using UnityEngine;

public class SaveLoadManagerJson : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string filePath;
    void Start()
    {
        filePath = Application.persistentDataPath + "/savefile.json";
    }

    //dentro de la funcion se piden las variables que se quieran guardar
    public void SaveGame()
    {
        SaveLoad data = new SaveLoad();
        //se llena el archivo data...
        //data.speed=...

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);

        Debug.Log("Save game in:"+ filePath);
    }

    public SaveLoad LoadGame()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveLoad data = JsonUtility.FromJson<SaveLoad>(json);

            Debug.Log("Game Loaded");
            return data;
        }
        else
        {
            Debug.Log("No se encontro el archivo");
            return null;
        }
    }
}
