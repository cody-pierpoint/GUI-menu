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
    public GameObject mainmenuPanel;
    public Animator transitions;
    public float transitionTime = 1f;
    public GameObject menuPanel;
    public GameObject fadepanel;
    public GameObject optionsPanel;
    private void Start()
    {
        fadepanel.SetActive(true);
        transitions.SetTrigger("Start");
        /*new WaitForSeconds(transitionTime);
        if(transitionTime == 1f)
        {
            fadepanel.SetActive(false);
            menuPanel.SetActive(true);
            anybuttonPanel.SetActive(true);
        }
        */
    }

    public void OptionsFadein()
    {

        transitions.SetTrigger("Start");

    }
    public void OptionsFadeOut()
    {

        transitions.SetTrigger("End");

    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
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
        if (Input.anyKey)
        {
            anybuttonPanel.SetActive(false);

        }
        if (anybuttonPanel.activeSelf == false)
        {
            mainmenuPanel.SetActive(true);

        }

    }
    public void Update()
    {
        PressAnyButton();
    }




}
