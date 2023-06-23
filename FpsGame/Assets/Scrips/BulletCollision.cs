using UnityEngine;
using UnityEngine.Events;

public class BulletCollision : MonoBehaviour
{
    public UnityEvent onBulletCollide;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie") || other.gameObject.CompareTag("BigZombie") || other.gameObject.CompareTag("LittleZombie"))
        {
            onBulletCollide.Invoke();
        }
    }
}