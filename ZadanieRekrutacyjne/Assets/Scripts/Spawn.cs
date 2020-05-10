using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float najnizszytime = 4;
    public float najwyzszytime = 10;
    public float time = 0;
    public List<SpawnPoint> punkty;
    public int maxRandom = 1000;

    // Start is called before the first frame update
    void Spawner()
    {
        
        if (punkty != null)
            punkty[Random.Range(0, punkty.Count)].GetComponent<SpawnPoint>().Spawn();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > najnizszytime && Random.Range(0, maxRandom) < 5)
        {
            Spawner();
            time = 0;
        }
        if (time >= najwyzszytime)
        {
            Spawner();
            time = 0;
        }
    }
}
