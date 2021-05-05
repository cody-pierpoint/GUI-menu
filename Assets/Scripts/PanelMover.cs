using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMover : MonoBehaviour
{
    public float transitionTime = 2;
    public bool menuUp = true;
    float timeToTransition;
    RectTransform form;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

     if(Input.GetKeyDown(KeyCode.Q))
        {
            timeToTransition = Time.time + transitionTime;               //make the transition
            
            //Vector3 lerpPos = Vector3.Lerp(form.position,)
            form.position += Vector3.up * Time.deltaTime;

        }
    }
}
