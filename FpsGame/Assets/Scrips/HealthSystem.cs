using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Image healthImage;
    private float initialWidth;
    private float currentWidth;
    public UnityEvent onZombieCollide;
    public UnityEvent onLittleZombieCollide;
    public UnityEvent onBigZombieCollide;

    private void Start()
    {
        currentHealth = maxHealth;
        initialWidth = healthImage.transform.localScale.x;
        currentWidth = initialWidth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
       
        currentWidth -= (initialWidth * 0.25f);
        healthImage.GetComponent<RectTransform>().rect.Set(0, 0, currentWidth, 30);
    
        currentWidth -= (initialWidth * 0.75f);
        healthImage.GetComponent<RectTransform>().rect.Set(0, 0, currentWidth, 30);
        currentWidth -= (initialWidth * 0.1f);
        healthImage.GetComponent<RectTransform>().rect.Set(0, 0, currentWidth, 30);

    }
}