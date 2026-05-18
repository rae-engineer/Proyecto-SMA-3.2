using UnityEngine;

public class loadDecision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    SaveLoadManagerJson saveload;
    public GameObject firstPanel;
    public GameObject[] panelDeciciones;
    private int escenaguardada;
    private void Awake()
    {
        saveload = FindAnyObjectByType<SaveLoadManagerJson>();
    }
    void Start()
    {
        loadGame();
    }
    public void loadGame()
    {
        SaveLoad loadedData = saveload.LoadGame();
        if (loadedData != null)
        {
            escenaguardada = loadedData.decision;
            firstPanel.SetActive(false);
            panelDeciciones[escenaguardada].SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
