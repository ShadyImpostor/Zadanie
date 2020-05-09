using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float hp = 20;
    public float aftermath = 3;
    bool isAlive = true;
    public float predkosc = 20;
    public GameObject player;
    private Rigidbody rigidbody;
    private bool fatal = false;
    CapsuleCollider colider;
    

    // Start is called before the first frame update
    void Start()
    {
        colider = GetComponent<CapsuleCollider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            UnityEngine.Vector3 direction;
            direction = player.transform.position - transform.position;
            transform.position += direction * predkosc * Time.deltaTime;

            if (hp <= 0)
                isAlive = false;

        }
        else
        {
            aftermath -= Time.deltaTime;
            rigidbody.isKinematic = false;
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            //colider.
            if (fatal==false)
            {
                fatal = true;
                rigidbody.AddForce(30, 0, 10);
            }
            if (aftermath <= 0)
                Destroy(this.gameObject);
           
        }

    }
}
