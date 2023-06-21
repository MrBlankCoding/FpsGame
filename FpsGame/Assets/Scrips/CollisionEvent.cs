using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CollisionEvent : MonoBehaviour
{
    public UnityEvent onCollideWithGround;
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            onCollideWithGround.Invoke();
    }
}
