using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[System.Serializable]
public class MoveEvent : UnityEvent<float> { }
public class PlayerMover : MonoBehaviour
{

    public UnityEvent onFirePressed;
    public MoveEvent XMove;
    public MoveEvent YMove;
    public UnityEvent onJumpPressed;
    public bool canJump;
    public float timeBetweenJump = 1;
    private float timeUntilNextJump;

    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            XMove.Invoke(Input.GetAxis("Horizontal"));
        }

        if (Input.GetButton("Vertical"))
        {
            YMove.Invoke(Input.GetAxis("Vertical"));
        }

        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            onJumpPressed.Invoke();
            canJump = false;
            timeUntilNextJump = Time.time + timeBetweenJump;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            onFirePressed.Invoke();
        }

        if (Time.time > timeUntilNextJump)
        {
            canJump = true;
        }
    }
}


