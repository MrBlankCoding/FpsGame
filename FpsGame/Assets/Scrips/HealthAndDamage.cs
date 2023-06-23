using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;

public class HealthAndDamage : MonoBehaviour
{
    [SerializeField] private Animator Death;
    [SerializeField] private string Dying = "Z_FallingBack";
    public int health = 100;
    
    void Start()
    {
        
    }


    void Update()
    {
        if (health == 0)
        {
            Death.Play(Dying);
            Destroy(this.gameObject);
        }
    }
     public void Damage()
    {

        health -= 50;        
      
    }
}
