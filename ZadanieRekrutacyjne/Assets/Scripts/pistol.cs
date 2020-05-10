using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class pistol : MonoBehaviour
{
    public float lifetime= 5;
    public float damage = 5;
    public float speed = 5;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.GetComponent<enemy>().hp -= damage;
        Destroy(this.gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
            Destroy(this.gameObject);
      
    }
}
