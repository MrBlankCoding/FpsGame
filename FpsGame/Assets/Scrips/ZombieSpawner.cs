using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public float spawnRate = 60;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(zombie, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(zombie, transform.position, transform.rotation);
            timer = 0;
        }
    }
}