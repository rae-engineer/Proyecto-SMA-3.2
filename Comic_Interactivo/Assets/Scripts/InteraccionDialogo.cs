using UnityEngine;
using TMPro;

public class InteraccionDialogo : MonoBehaviour
{
    public GameObject PanelDialogo;

    private void Start()
    {
        PanelDialogo.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PanelDialogo.SetActive(true);
            Debug.Log("Mostrar Dialogo");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PanelDialogo.SetActive(false);
        }
    }
}
