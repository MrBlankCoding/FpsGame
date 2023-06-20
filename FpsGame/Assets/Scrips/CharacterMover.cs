using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMover : MonoBehaviour
{
        public float speed = 10;
        Rigidbody rb;
        float jumpForce = 8.0f;
        bool jumping = false;

        // Start is called before the first frame update
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        public void MoveLeftRight(float axis)
        {
            Debug.Log("Horizontal" + axis);
            transform.Translate(Vector3.right * speed * Time.deltaTime * axis);
        }
        public void MoveFowardBack(float axis)
        {
            Debug.Log("Vertical" + axis);
            transform.Translate(Vector3.forward * speed * Time.deltaTime * axis);
        }
        public void jump()
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumping = true;
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                Destroy(other.gameObject);
            }
        }
        void OnCollisionEnter(Collision other)
        {

            if (other.gameObject.CompareTag("BeachBall"))
            {
                Debug.Log("Good Kick");
            }

            if (other.gameObject.CompareTag("Ground"))
            {
                jumping = false;
                Debug.Log("Good Kick");
            }

        }
}


