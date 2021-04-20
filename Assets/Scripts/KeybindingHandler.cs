using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeybindingHandler : MonoBehaviour
{
    [SerializeField]
    public static Dictionary<string, KeyCode> Keys = new Dictionary<string, KeyCode>();

    //
    [System.Serializable]

    public struct KeyUISetup
    {
        public string keyName;
        public TextMeshProUGUI keyDisplayText;
        public string defaultKey;

    }

    public KeyUISetup[] baseSetup;
    public GameObject currentButton;
    public Color32 ChangedKey = Color.yellow;   // new Color32(40, 70, 250, 255);
    public Color32 selectedKey = Color.blue;    //new Color32(255, 100, 30, 25);

    private void Start()
    {
        for (int i = 0; i < baseSetup.Length; i++)
        {
            baseSetup[i].keyDisplayText.transform.parent.name = baseSetup[i].keyName; // 

            Keys.Add(baseSetup[i].keyName, (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(baseSetup[i].keyName, baseSetup[i].defaultKey)));

            baseSetup[i].keyDisplayText.text = Keys[baseSetup[i].keyName].ToString();

        }
    }

    public void SaveKeys()
    {
        foreach (var thisKey in Keys)
        {
            PlayerPrefs.SetString(thisKey.Key, thisKey.Value.ToString());
        }
        PlayerPrefs.Save();
    }

    public void LoadKey()
    {
        for (int i = 0; i < baseSetup.Length; i++)
        {
            //string newKey = Keys[baseSetup[i].keyName].ToString();
            //newKey = PlayerPrefs.GetString(baseSetup[i].keyName);
            baseSetup[i].keyDisplayText.transform.parent.GetComponent<Image>().color = Color.white;
        }
    }

    public void ChangeKey(GameObject clickedKey)
    {
        currentButton = clickedKey;
        if (clickedKey != null)
        {
            currentButton.GetComponent<Image>().color = selectedKey;

        }

    }
    public void OnGUI()
    {
        string newKey = "";
        Event e = Event.current;
        if (currentButton == null)
            return;
        if (e.isKey)
        {
            newKey = e.keyCode.ToString();

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            newKey = "LeftShift";
        }
        else if (Input.GetKeyDown(KeyCode.RightShift))
        {
            newKey = "RightShift";

        }

        if (newKey != "")
        {
            Debug.Log(currentButton.name);
            Debug.Log(newKey);

            Keys[currentButton.name] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey);

            currentButton.GetComponentInChildren<TextMeshProUGUI>().text = newKey;

            currentButton.GetComponent<Image>().color = ChangedKey;

            currentButton = null;

        }


    }

   /* private void Update()
    {
        if (Input.GetKey(HotKeyRebinder.Keys)["forwards"])))
                {


        }
    }
   */

}
