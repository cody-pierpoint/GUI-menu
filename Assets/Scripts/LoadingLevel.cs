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
   // public GameObject anybuttonPanel;
    public GameObject mainMenuPanel;
    public Animator transitions;
    public float transitionTime = 0f;
    public GameObject fadePanel;
    public GameObject optionsPanel;
    private bool isOpen;
    private void Start()
    {
        fadePanel.SetActive(true);
        transitions.SetTrigger("Start");
       // anybuttonPanel.SetActive(true);
        /*new WaitForSeconds(transitionTime);
        if(transitionTime == 1f)
        {
            fadepanel.SetActive(false);
            menuPanel.SetActive(true);
            
        }
        */
    }

 
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        transitions.SetTrigger("End");
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
        //transitions.SetTrigger("End");
        StartCoroutine(loadLevelAnim(sceneIndex));
       // save();

    }

    IEnumerator loadLevelAnim(int sceneIndex)
    {
        fadePanel.SetActive(true);
        transitions.SetTrigger("End");
        yield return new WaitForSeconds(transitionTime);
        StartCoroutine(LoadAsynchronously(sceneIndex));


    }

    public void QuitGame()
    {
        Application.Quit();



    }

    public void PressAnyButton()
    {
       // if (Input.anyKey && anybuttonPanel.activeSelf)
        {

           // anybuttonPanel.SetActive(false);

           // if (anybuttonPanel.activeSelf == false)
            {

          //      mainMenuPanel.SetActive(true);

            }
        }


    }
    public void Update()
    {
        PressAnyButton();
    }

    public void PlayAnimStart()
    {
        StartCoroutine(EnterOptionsAnim());



    }

    public void playAnimEnd()
    {
        StartCoroutine(ExitOptionsAnim());
    }
    IEnumerator EnterOptionsAnim()
    {
        //isOpen = true;
        //isOpen = transitions.GetBool("Open");
        fadePanel.SetActive(true);
        transitions.SetTrigger("OptionsFadeIn");
        transitions.SetTrigger("OpttionsFadeOut");
        //mainmenuPanel.SetActive(false);
        //transitions.SetBool("Open", isOpen);
        //transitions.SetBool("Open", !isOpen);

        yield return new WaitForSeconds(transitionTime);
        //fadepanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);

    }
    IEnumerator ExitOptionsAnim()
    {
        //bool isClosed = false;
        // isClosed = transitions.GetBool("Closed");
        fadePanel.SetActive(true);

        //transitions.SetBool("Closed", !isClosed);
        transitions.SetTrigger("Test1");
        transitions.SetTrigger("Test2");
        //transitions.SetBool("Closed", isClosed);

        yield return new WaitForSeconds(transitionTime);
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);

    }

    




}
