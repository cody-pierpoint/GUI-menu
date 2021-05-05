using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class AnimScript : MonoBehaviour
{
    public Animator transitions;
    public float transitionTime = 1f;
   // public GameObject anybuttonsceen;

    public void Start()
    {
        transitions.SetTrigger("Start");
    }

    public void LoadScene(int scene)
    {
        transitions.SetTrigger("End");
        new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
    }
    
}
/*IEnumerator loadLevel(int sceneIndex)
{
    transitions.SetTrigger("Start");
    yield return new WaitForSeconds(transitionTime);

    SceneManager.LoadScene(sceneIndex);

}
*/
