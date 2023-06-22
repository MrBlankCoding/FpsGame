using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupSpin : MonoBehaviour
{
    private Vector3 Rotation = new Vector3(0.1f, 0, 0);
    public UnityEvent healthGrabbed;
    private Vector3 position;
    
    private void Awake()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * Time.deltaTime * 50);
    }
    public void death()
    {
        Destroy(gameObject);
    }
}