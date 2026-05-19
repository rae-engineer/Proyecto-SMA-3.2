using UnityEngine;

public class audiomanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip[] audios;
    private AudioSource efectosSource;
    void Start()
    {
        efectosSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void seleccionAudio(int indice)
    {
        efectosSource.PlayOneShot(audios[indice]);
    }
}
