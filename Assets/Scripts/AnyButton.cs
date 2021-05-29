using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnyButton : MonoBehaviour
{
    public GameObject fadePanel;
    public GameObject pressAnyButtonPanel;
    public GameObject mainMenuPanel;
    public Animator transitions;
    // Start is called before the first frame update
    void Start()
    {
        //fadePanel.SetActive(true);
        //transitions.SetTrigger("Start");
        pressAnyButtonPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        PressAnyButton();
    }

    void PressAnyButton()
    {
        if(Input.anyKey && pressAnyButtonPanel.activeSelf)
        {
            pressAnyButtonPanel.SetActive(false);
            
            if(pressAnyButtonPanel.activeSelf == false)
            {
                mainMenuPanel.SetActive(true);
            }

        }
    }

}
