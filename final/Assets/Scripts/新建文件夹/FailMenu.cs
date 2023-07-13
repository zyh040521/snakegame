using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailMenu : MonoBehaviour
{
    public TMP_Text text;
    public GameObject dataa;

    // Start is called before the first frame update 
   public void Restart()
    {
        Application.LoadLevel("Level1");
        
    }

    public void BackMenu()
    {
        Destroy(dataa);
        Application.LoadLevel("Start menu");
    }

    public void exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif

    }
    private void Start()
    {
        dataa = GameObject.Find("SetData");
        int FS = dataa.GetComponent<SetData>().scoree;
        text.text = FS.ToString(); 
    }
}

