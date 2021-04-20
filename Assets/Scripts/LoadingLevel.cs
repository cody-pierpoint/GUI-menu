using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class LoadingLevel : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image progressBar;
    public TextMeshProUGUI progressText;
    public GameObject anybuttonPanel;

    private void Start()
    {
        anybuttonPanel.SetActive(true);
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            progressBar.fillAmount = progress;
            progressText.text = "Loading " + progress * 100 + "%";
            yield return null;

        }
    }
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));


    }

    public void QuitGame()
    {
        Application.Quit();



    }

    public void PressAnyButton()
    {
        if(Input.anyKey)
        {
            anybuttonPanel.SetActive(false);

        }


    }
    public void Update()
    {
        PressAnyButton();
    }




}
