using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public Image hpbar;
    public float hp = 20;
    public float maxhp = 20;
    public float aftermath = 3;
    float height;
    public bool isAlive = true;
    public float predkosc = 20;
    GameObject player;
    private Rigidbody rigidbody;
    private bool fatal = false;
    CapsuleCollider colider;
    Transform playerTransform;
    UnityEngine.Vector3 direction;
  
    // Start is called before the first frame update
    void Start()
    {
        height = transform.position.y;
        colider = GetComponent<CapsuleCollider>();
        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        hpbar.fillAmount = hp / maxhp;

        if (isAlive)
        {

            direction = playerTransform.position - transform.position;
            transform.position += direction.normalized * predkosc * Time.deltaTime;
            transform.position = new UnityEngine.Vector3(transform.position.x, height, transform.position.z);

            if (hp <= 0)
                isAlive = false;

        }
        else
        {
            aftermath -= Time.deltaTime;
            rigidbody.isKinematic = false;
            rigidbody.constraints = 0;
            //colider.
            if (fatal == false)
            {
                fatal = true;
                rigidbody.AddForce(30, 0, 10);
            }
            if (aftermath <= 0)
                Destroy(this.gameObject);

        }

    }
}