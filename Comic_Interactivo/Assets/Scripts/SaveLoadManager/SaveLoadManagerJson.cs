using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManagerJson : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string filePath;

    private string escenaName;
    void Start()
    {
         escenaName = SceneManager.GetActiveScene().name;

        filePath = Application.persistentDataPath + "/savefile.json";
    }

    //dentro de la funcion se piden las variables que se quieran guardar
    public void SaveGame(int decision)
    {
        SaveLoad data = new SaveLoad();
        //se llena el archivo data...
        data.escena = escenaName;
        data.decision = decision;

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

    public void deleteData()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("Datos eliminados correctamente.");
        }
        else
        {
            Debug.Log("No existe archivo para eliminar.");
        }
    }
}
