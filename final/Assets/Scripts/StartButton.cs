using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnButtonClick()
    {
        Startgame();
    }

   public void Startgame()
    {
        Debug.Log("ÇÐ»»µ½Level 1");
        Application.LoadLevel("Level1");
    }
}
