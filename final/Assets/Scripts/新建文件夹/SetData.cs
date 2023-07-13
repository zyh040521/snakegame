using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetData : MonoBehaviour
{
    public int state;
    public TMP_Text text;
    public int scoree = 0;
    public bool isound;
    public Button but;
    public Sprite[] soundsprites;
    // Start is called before the first frame update
    void Start()
    {
        isound = true;
        state = 2; 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(state);
        
    }
    public void high()
    {
        state = 3;
        text.text = "Current Difficulty: Hard";
    }
    public void normal()
    {
        state = 2;
        text.text = "Current Difficulty: Normal";


    }

    public void easy()
    {
        state = 1;
        text.text = "Current Difficulty: Easy";
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void switching()
    {
        isound=!isound;
        if(isound == true)
        {
            but.GetComponent<Image>().sprite = soundsprites[0];
        }
        else
        {
            but.GetComponent<Image>().sprite = soundsprites[1];
        }
            
    }
}
