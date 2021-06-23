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
        pressAnyButtonPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        PressAnyButton();
    }

    void PressAnyButton()
    {
        //if any key is pressed and anybutton panel is active
        if(Input.anyKey && pressAnyButtonPanel.activeSelf)
        {
            //any button panel is not active
            pressAnyButtonPanel.SetActive(false);
            //if any button panel is not active
            if(pressAnyButtonPanel.activeSelf == false)
            {
                // main menu is active
                mainMenuPanel.SetActive(true);
            }

        }
    }

}
