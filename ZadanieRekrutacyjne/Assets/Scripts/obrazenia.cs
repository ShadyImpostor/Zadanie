using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obrazenia : MonoBehaviour
{
    public float damage = 2;
    bool timein = false;
    public float czasmax = 1;
    public float czasaktualny = 1;
    enemy character;
    void OnTriggerStay(Collider collision)
    {
        
        if (collision.gameObject.name == "Player" && timein == false && character.isAlive)
        {
            timein = true;
            collision.gameObject.GetComponent<Poruszanie>().health -= damage;
            
        }

        
    }
    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponentInParent<enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timein == true)
        {
            czasaktualny -= Time.deltaTime;
        }
        if (czasaktualny <= 0)
        {
            czasaktualny = czasmax;
            timein = false;
        }
    }
}
