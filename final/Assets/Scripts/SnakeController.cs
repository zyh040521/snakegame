using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using JetBrains.Annotations;
using UnityEngine.Playables;
using Unity.VisualScripting;

public class SnakeController : MonoBehaviour
{
    public GameObject bodyPrefab;
    public GameObject head;
    public GameObject Player;
    public TMP_Text Scoretext ;
    public Button but;
    public Sprite[] pausesprites;
    public GameObject data;
    public AudioSource audioSource;
    public Vector3[] vectorArray;


    private int length;
    private Vector3 up = new Vector3(0, 0, 0.78f);
    private Vector3 down = new Vector3(0, 0, -0.78f);
    private Vector3 left = new Vector3(-0.78f, 0, 0);
    private Vector3 right = new Vector3(0.78f, 0, 0);
    private Vector3 direction;
    private int p = 1;
    private float timer;
    public float threshold;
    public int score;
    private bool playmusic;
    public bool pause = false;

    // Start is called before the first frame update
    void Start()
    {
        vectorArray = new Vector3[]
        {
            up,
            right
        };
        
        int x = Random.Range(8, 11);
        int z = Random.Range(8, 11);
        head.transform.position = new Vector3(x + 0.5f, 0, z + 0.5f);
        Debug.Log(x+z);


        data = GameObject.Find("SetData");
        data.GetComponent<SetData>().scoree = 0;
        playmusic = data.GetComponent<SetData>().isound;
        if (playmusic)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
        int s = data.GetComponent<SetData>().state;
        Debug.Log("s=" + s);    
        if(s == 1)
        {
            threshold = 0.5f;
        }
        else
        {
            if(s ==2)
            {
                threshold = 0.33f;
            }
            else
            {
                threshold = 0.20f;
            }
        }
        score = 0;
        length = 2;
        int inidic=Random.Range(0,2);
        direction = vectorArray[inidic];
        timer=0;
        for (int n = 0; n < length; n++)
        {
            GameObject body = Instantiate(bodyPrefab, transform);
            body.transform.position = new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z - (n + 0.78f));
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(direction);
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(!(transform.GetChild(0).position.z>head.transform.position.z))
                direction = up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if(!(transform.GetChild(0).position.z<head.transform.position.z))
                direction = down;
            
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if(!(transform.GetChild(0).position.x<head.transform.position.x))
                direction = left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if(!(transform.GetChild(0).position.x>head.transform.position.x))
                direction = right;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if(pause == false)
            {
                p = 0;
                but.GetComponent<Image>().sprite = pausesprites[0];
                pause = true;
            }
            else
            {
                p = 1;
                but.GetComponent<Image>().sprite = pausesprites[1];
                pause = false;
            }
        }
        
        if(timer>threshold)
        {
            for(int n=length-1;n>0;n--)
            {
                transform.GetChild(n).transform.position=transform.GetChild(n-1).transform.position;
                transform.GetChild(n).transform.rotation = transform.GetChild(n - 1).transform.rotation;
            }
            transform.GetChild(0).transform.position=head.transform.position;
            transform.GetChild(0).transform.rotation = head.transform.rotation;
            Debug.Log(head.transform.position.y);
            head.transform.position += direction;
            if (direction == up)
            {
                head.transform.rotation = Quaternion.Euler(new Vector3(270, 0, 0));
            }else if (direction == down)
            {
                head.transform.rotation = Quaternion.Euler(new Vector3(270, 180, 0));
            }
            else if (direction == left)
            {
                head.transform.rotation = Quaternion.Euler(new Vector3(270, 270, 0));
            }
            else if (direction == right)
            {
                head.transform.rotation = Quaternion.Euler(new Vector3(270, 90, 0));
            }
            timer =0;
        }
        timer += Time.deltaTime * p;
    }
    public void getApple()
    {
        GameObject body= Instantiate(bodyPrefab,transform);
        body.transform.position=transform.GetChild(length-1).position;
        length = length + 1;
        int s = data.GetComponent<SetData>().state;
        score = score + 10 + 2 * length + s * 3;
        Scoretext.text = "Your score :" + score;
        data.GetComponent<SetData>().scoree = score;
        if (threshold>0.2f)
        {
            threshold*=0.95f;
        }
    }
    public void Pause()
    {
        if (pause == false)
        {
            p = 0;
            but.GetComponent<Image>().sprite = pausesprites[0];
            pause = true;
        }
        else
        {
            but.GetComponent<Image>().sprite = pausesprites[1];
            p = 1;
            pause = false;
        }




        
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Head") 
        {
            Debug.Log("ײ��������");
            Player.GetComponent<PLayer>().Die();
        }



    

    }
    
    
  
    
}

