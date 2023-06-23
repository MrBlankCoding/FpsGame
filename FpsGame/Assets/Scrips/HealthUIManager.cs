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
    public UnityEvent onZombieCollide;
    public UnityEvent onLittleZombieCollide;
    public UnityEvent onBigZombieCollide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnZombieCollide(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            currentWidth -= (initialWidth * 0.25f);
            healthImage.GetComponent<RectTransform>().rect.Set(0, 0, currentWidth, 30);

        }
    }

    public void OnBigZombieCollide(Collision collision)
    {
        if (collision.gameObject.tag == "BigZombie")
        {
            currentWidth -= (initialWidth * 0.75f);
            healthImage.GetComponent<RectTransform>().rect.Set(0, 0, currentWidth, 30);
        }
    }


    public void OnLittleZombieCollide(Collision collision)
    {
        if (collision.gameObject.tag == "LittleZombie")
        {
            currentWidth -= (initialWidth * 0.1f);
            healthImage.GetComponent<RectTransform>().rect.Set(0, 0, currentWidth, 30);
        }
    }

}
