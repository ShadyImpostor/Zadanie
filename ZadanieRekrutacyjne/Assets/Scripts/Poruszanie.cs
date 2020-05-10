using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poruszanie : MonoBehaviour
{
    private shotgun strzal;
    public float speed = 5;
    public float health = 10;
    public Text hp;
    public Text bron;
    bool isAlive = true;
    public GameObject bullet;
    public GameObject shootpoint;
    public GameObject body;
    public GameObject strzelba;
    private Transform bodytransform;
    string aktualnabron ="Pistolet";
    private bool shotgun = false;
    private bool pistol = true;
    public Light pistolflash;
    pistollight pistollightingscript;
    public GameObject czlowiek;
    private Namierzanie namierzanie;

    // Start is called before the first frame update
    void Start()
    {
        namierzanie = czlowiek.GetComponent<Namierzanie>();
        pistollightingscript = pistolflash.GetComponent<pistollight>();
        bodytransform = body.GetComponent<Transform>();
        strzal = strzelba.GetComponent<shotgun>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            namierzanie.SetAlive(false);
            health = 0;
            isAlive = false;
            
        }

        hp.text = "Ilość życia: " + health.ToString();

        bron.text = "Aktualna Bron: " + aktualnabron;

        if (pistol == true)
            aktualnabron = "Pistolet";

        if (shotgun == true)
            aktualnabron = "Shotgun";

        if (Input.GetKey(KeyCode.W) && isAlive)
            transform.position += transform.forward * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.S) && isAlive)
            transform.position += transform.forward * (-1) * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.D) && isAlive)
            transform.position += transform.right * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.A) && isAlive)
            transform.position += transform.right * (-1) * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.Space) && pistol == true && isAlive)
        {
            //      Object.Instantiate(bullet,transform.position, transform.rotation);
            GameObject o = GameObject.Instantiate(bullet, shootpoint.transform.position, bodytransform.rotation);
            o.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && shotgun == true && isAlive)
        {
            pistollightingscript.Light();
            strzal.shot();           
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            pistol = !pistol;           
            shotgun = !shotgun;

          



        }
      
    }
}
