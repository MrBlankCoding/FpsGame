using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthUI : MonoBehaviour
{
    public Image healthImage;
    private float initialWidth;
    private float currentWidth;
    public UnityEvent onZombieCollide;
    public UnityEvent onLittleZombieCollide;
    public UnityEvent onBigZombieCollide;

    // Start is called before the first frame update
    void Start()
    {
        initialWidth = healthImage.transform.localScale.x;
        currentWidth = initialWidth;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            currentWidth -= (initialWidth * 0.25f);
            healthImage.GetComponent<RectTransform>().rect.Set(0, 0, currentWidth, 30);
            
        }
    }
    
}
