using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgun : MonoBehaviour
{
    public GameObject enemy;
    public float damage = 30;
    public List<GameObject> targets;

   
    // Start is called before the first frame update
    void Start()
    {
        targets = new List<GameObject>();
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.GetComponent<enemy>() != null)
        {
            targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<enemy>() != null)
        {
            targets.Remove(other.gameObject);
        }
    }

    public void shot ()
    {
        for (int i=0; i < targets.Count; i++)
        {
            targets[i].GetComponent<enemy>().hp -= damage;

        }
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] == null)
                targets.Remove(targets[i]);
        }

    }
}
