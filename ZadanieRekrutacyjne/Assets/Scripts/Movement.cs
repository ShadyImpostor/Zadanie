using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocity = 3;
    public float speed=20;
    public GameObject kamera;
    public Camera cam;
    public float x;
    public float y;
    public GameObject bullet;
    public GameObject shootpoint;
    // Start is called before the first frame update
    void Start()
    {
        cam = kamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        UnityEngine.Vector3 direction;
        if (Physics.Raycast(ray, out hit))
        {
            UnityEngine.Vector3 objectHit = hit.point;
            direction =(objectHit - transform.position).normalized;
            UnityEngine.Quaternion _lookRotation = UnityEngine.Quaternion.LookRotation(direction);
            
            transform.rotation = UnityEngine.Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * speed);
            transform.rotation = UnityEngine.Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
                }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //      Object.Instantiate(bullet,transform.position, transform.rotation);
            GameObject o = GameObject.Instantiate(bullet,shootpoint.transform.position, transform.rotation);
            o.SetActive(true);
        }

    }
}



