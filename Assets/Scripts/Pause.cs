using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public bool isPaused;
    public GameObject optionsMenu;
    
    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<FirstPersonFlight>();
    }
    public void Paused()
    {
        isPaused = true;

        Time.timeScale = 0;

        pausePanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        

    }

    public void UnPaused()
    {
        isPaused = false;
        Time.timeScale = 0;
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;


    }
    private void TogglePause()
    {
        if (!isPaused)
        {
            Paused();
        }
        else
        {
            UnPaused();

        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            

            if(!isPaused)
            Paused();

            else 
            {
                UnPaused();
            }
            
            /*if(!optionsMenu.activeSelf)
             {
                 TogglePause();
             }
             else
             {
                 pausePanel.SetActive(true);
                 optionsMenu.SetActive(false);
             }
             */
        }
       
        
    }
}
