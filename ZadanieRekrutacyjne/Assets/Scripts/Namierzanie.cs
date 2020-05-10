using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Namierzanie : MonoBehaviour
{
    public float velocity = 3;
    public float speed=20;
    public GameObject kamera;
    Camera cam;
    public float x;
    public float y;
    bool isAlive =true;
    // Start is called before the first frame update
    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }
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
        if (Physics.Raycast(ray, out hit) && isAlive)
        {
            UnityEngine.Vector3 objectHit = hit.point;
            direction =(objectHit - transform.position).normalized;
            UnityEngine.Quaternion _lookRotation = UnityEngine.Quaternion.LookRotation(direction);
            
            transform.rotation = UnityEngine.Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * speed);
            transform.rotation = UnityEngine.Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
                }

     

    }
}



