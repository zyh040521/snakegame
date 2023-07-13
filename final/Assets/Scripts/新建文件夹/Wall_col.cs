using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_col : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Head") 
        {
            Debug.Log("撞墙");
            Player.GetComponent<PLayer>().Die();
        }
           
    }
}
