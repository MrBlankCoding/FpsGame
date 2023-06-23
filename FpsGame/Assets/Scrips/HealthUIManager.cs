using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class HealthUIManager : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Image healthImage;
    private float initialWidth;
    private float currentWidth;

    private void Start()
    {
        currentHealth = maxHealth;
        initialWidth = healthImage.rectTransform.sizeDelta.x;
        currentWidth = initialWidth;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            currentWidth -= (initialWidth * 0.25f);
            healthImage.rectTransform.sizeDelta = new Vector2(currentWidth, 30);
        }
        else if (collision.gameObject.CompareTag("BigZombie"))
        {
            currentWidth -= (initialWidth * 0.75f);
            healthImage.rectTransform.sizeDelta = new Vector2(currentWidth, 30);
        }
        else if (collision.gameObject.CompareTag("LittleZombie"))
        {
            currentWidth -= (initialWidth * 0.1f);
            healthImage.rectTransform.sizeDelta = new Vector2(currentWidth, 30);
        }
    }
}