using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigZombieSpawner : MonoBehaviour
{
    public GameObject bigZombie;
    public float SpawnRate = 60;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bigZombie, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < SpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(bigZombie, transform.position, transform.rotation);
            timer = 0;
        }
    }
}