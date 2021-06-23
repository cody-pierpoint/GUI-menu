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
        //fade panel is active
        fadePanel.SetActive(true);
        //play animation "Start"
        transitions.SetTrigger("Start");
    }

 
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        //play animation "End"
        transitions.SetTrigger("End");
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        //loading screen is active
        loadingScreen.SetActive(true);


        //while operation is not done
        while (!operation.isDone)
        {
            //progress = operation progress / 0.9;
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            //fill progress bar amount based on progress
            progressBar.fillAmount = progress;
            //loading text display progress as %
            progressText.text = "Loading " + progress * 100 + "%";
            yield return null;

        }
    }
    public void LoadLevel(int sceneIndex)
    {
       
        //start coroutine
        StartCoroutine(loadLevelAnim(sceneIndex));
    

    }

    IEnumerator loadLevelAnim(int sceneIndex)
    {
        //fadepanel is active
        fadePanel.SetActive(true);
        //play animation "End"
        transitions.SetTrigger("End");
        //wait for transition time
        yield return new WaitForSeconds(transitionTime);
        //start coroutine
        StartCoroutine(LoadAsynchronously(sceneIndex));


    }

    public void QuitGame()
    {
        Application.Quit();



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
        //fade panel is active
        fadePanel.SetActive(true);
        //play fade in and fade out animation
        transitions.SetTrigger("OptionsFadeIn");
        transitions.SetTrigger("OpttionsFadeOut");
        //wait for transition time
        yield return new WaitForSeconds(transitionTime);
        //set mainmenu panel is set to inactive
        mainMenuPanel.SetActive(false);
        //set options panel is set in active
        optionsPanel.SetActive(true);

    }
    IEnumerator ExitOptionsAnim()
    {
        //fade panel is active
        fadePanel.SetActive(true);

        //play animations "Test1" and "Test2"
        transitions.SetTrigger("Test1");
        transitions.SetTrigger("Test2");
        //wait for transition time
        yield return new WaitForSeconds(transitionTime);
        //options panel is inactive
        optionsPanel.SetActive(false);
        //main menu panel is active
        mainMenuPanel.SetActive(true);

    }

    




}
