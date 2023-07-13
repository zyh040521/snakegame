using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greensnake : MonoBehaviour
{
    Vector3 trans1;
    Vector3 trans2;

    public float amplitude = 10f;
    public float frequency = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        trans2 = transform.position;
        trans2.y = Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude + trans1.y;
        transform.position = trans2;
        // transform.Rotate(new Vector3(0, 0.2f, 0));
    }
}
