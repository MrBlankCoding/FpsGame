using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionEvent : MonoBehaviour
{
    public UnityEvent OnCollide;
    public UnityEvent onPlayerCollide;
    public UnityEvent onEnemyCollide;
    public UnityEvent onBulletTrigger;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            onEnemyCollide.Invoke();
            Debug.Log("Zombie");
        }
        if (other.gameObject.CompareTag("BigZombie"))
        {
            onEnemyCollide.Invoke();
            Debug.Log("Zombie");
        }
        if (other.gameObject.CompareTag("LittleZombie"))
        {
            onEnemyCollide.Invoke();
            Debug.Log("Zombie");
        }
        if (other.gameObject.tag == "Player")
        {
            onPlayerCollide.Invoke();
        }
        OnCollide.Invoke();
        if (other.gameObject.CompareTag("Bullet"))
        {
            onBulletTrigger.Invoke();
        }
    }
}