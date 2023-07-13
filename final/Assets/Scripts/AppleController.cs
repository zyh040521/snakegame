using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AppleController : MonoBehaviour
{
    public GameObject snake;
    Vector3 trans1;
    Vector3 trans2;
    public float amplitude = 10f;
    public float frequency = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(1, 20);
        int z = Random.Range(1, 20);
        transform.position = new Vector3(x + 0.5f, 0.5f, z + 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        trans2 = transform.position;
        trans2.y = Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude + trans1.y;
        transform.position = trans2;
        transform.Rotate(new Vector3(0, 0.2f, 0));

    }
    
    private void OnTriggerEnter(Collider col)
    {
        if(col.name=="Head")
        {
            snake.GetComponent<SnakeController>().getApple();
        }
        //     int x= Random.Range(1,20);
        //     int z= Random.Range(1,20);
        //     transform.position=new Vector3(x+0.5f,0.5f,z+0.5f);

        // }
        // while(col.CompareTag("Body(Clone)"))
        // {
        int x= Random.Range(1,20);
        int z= Random.Range(1,20);
        transform.position=new Vector3(x+0.5f,0.5f,z+0.5f);
        
    }
}
