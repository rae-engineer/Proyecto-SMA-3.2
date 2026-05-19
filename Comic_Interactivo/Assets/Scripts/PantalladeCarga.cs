using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using PixeLadder.EasyTransition;
using Unity.Loading;

public class PantalladeCarga : MonoBehaviour
{
    SaveLoadManagerJson saveload;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject PantallaCarga;

    [Header("Scene")]
    [SerializeField] private string sceneToLoad;
    [SerializeField] private TransitionEffect transitionEffects;



    [Header("Settings")]
    [SerializeField] private float loadingTime = 2f;
    [SerializeField] private int id = 2;

    public bool isfirst = false;

    public void StartLoading()
    {

        PantallaCarga.SetActive(true);
        StartCoroutine(LoadingRoutine());


    }

    private void Start()
    {
        saveload = FindAnyObjectByType<SaveLoadManagerJson>();
        if (id == 0 )
        {
            StartLoading();
        }
    }

    public void HomeLoad()
    {
        sceneToLoad = "Home";
        SaveLoad loadedData = saveload.LoadGame();
        if (loadedData != null && isfirst)
        {
            sceneToLoad = loadedData.escena;
        }
        

        StartLoading();

    }

    public void Capitulo1Load()
    {
        sceneToLoad = "Capitulo1(Mariana)";

        StartLoading();

    }

    public void Capitulo2Load()
    {
        sceneToLoad = "Capitulo2";

        StartLoading();
    }

    public void load()
    {

        SceneTransitioner.Instance.LoadTransition(transitionEffects);
    }

    private IEnumerator LoadingRoutine()
    {

        animator.SetTrigger("Start");

        float timer = 0f;

        while (timer < loadingTime)
        {
            timer += Time.deltaTime;

            float progress = timer / loadingTime;

            int percentage = Mathf.RoundToInt(progress * 100);

            loadingText.text = $"Cargando historia... {percentage}%";

            yield return null;
        }

        loadingText.text = "Cargando historia... 100%";

        yield return new WaitForSeconds(0.3f);

        SceneTransitioner.Instance.LoadScene(sceneToLoad, transitionEffects);

        yield return new WaitForSeconds(0.1f);
        

        SceneManager.LoadScene(sceneToLoad);
    }


    

}