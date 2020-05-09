using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float maxhp = 20;
    public float currenthp = 20;
    public float healthBarLength;
    public float aftermath = 3;
    bool isAlive = true;
    public float predkosc = 20;
    GameObject player;
    private Rigidbody rigidbody;
    private bool fatal = false;
    CapsuleCollider colider;
    Transform playerTransform;
    UnityEngine.Vector3 direction;

    public void AddjustCurrentHealth(int adj)
    {
        currenthp += adj;

        if (currenthp < 0)
            currenthp = 0;

        if (currenthp > maxhp)
            currenthp = maxhp;

        if (maxhp < 1)
            maxhp = 1;

        healthBarLength = (Screen.width / 6) * (currenthp / (float)maxhp);
    }
    // Start is called before the first frame update
    void Start()
    {
        healthBarLength = Screen.width / 6;
        colider = GetComponent<CapsuleCollider>();
        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        AddjustCurrentHealth(0);
        if (isAlive)
        {

            direction = playerTransform.position - transform.position;
            Debug.Log(direction);
            transform.position += direction.normalized * predkosc * Time.deltaTime;

            if (currenthp <= 0)
                isAlive = false;

        }
        else
        {
            aftermath -= Time.deltaTime;
            rigidbody.isKinematic = false;
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
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