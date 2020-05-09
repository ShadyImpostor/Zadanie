using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject player;
    public float height =0;
    protected Transform ruch;
    public float offset = 1;
    // Start is called before the first frame update
    void Start()
    {
        ruch = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position= new Vector3(ruch.position.x, height, ruch.position.z - offset);     
    }
}
