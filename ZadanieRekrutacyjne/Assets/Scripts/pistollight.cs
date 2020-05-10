using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistollight : MonoBehaviour
{
    public float timer=0.01f;
    public float maxtime= 0.01f;
    bool lighting = false;
    private Light swiatlo; 
    // Start is called before the first frame update

        public void Light()
    {
        lighting = true;

        swiatlo.intensity = 1;
        timer = maxtime;
    }
    void Start()
    {
        swiatlo = gameObject.GetComponent<Light>();
        timer = maxtime;
    }

    // Update is called once per frame
    void Update()
    {
        if (lighting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                swiatlo.intensity = 0;
        }
    }
}
