using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSceneFade : MonoBehaviour
{
    //[SerializeField] private LoadingLevel loadLevel;
    [SerializeField] Animator transitions;
    [SerializeField] GameObject fadePanel;


    // Start is called before the first frame update
    void Start()
    {
        fadePanel.SetActive(true);
        transitions.SetTrigger("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
