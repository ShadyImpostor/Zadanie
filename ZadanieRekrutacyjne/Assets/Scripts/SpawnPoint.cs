using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject enemy;
    public float height = 20;
    private bool spawned = true;
    // Start is called before the first frame update

        public void Spawn()
    {
       GameObject o = GameObject.Instantiate(enemy);
        //o.transform.position.Set(transform.position.x, height, transform.position.z);
        o.SetActive(false);
        //while (spawned)
        //{
        //    o.transform.position += new UnityEngine.Vector3(0, -0.1f, 0);
        //}
        o.SetActive(true);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "GroundPlane")
            spawned = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
