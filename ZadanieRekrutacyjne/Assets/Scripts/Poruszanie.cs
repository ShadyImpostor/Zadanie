using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poruszanie : MonoBehaviour
{
    public float speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.S))
            transform.position += transform.forward * (-1) * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.A))
            transform.position += transform.right * (-1) * Time.deltaTime * speed;

     
    }
}
