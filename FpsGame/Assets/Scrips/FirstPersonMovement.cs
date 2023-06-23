using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rb;
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        IsRunning = canRun && Input.GetKey(runningKey);


        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }


        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);


        rb.velocity = transform.rotation * new Vector3(targetVelocity.x, GetComponent<Rigidbody>().velocity.y, targetVelocity.y);
    }
}