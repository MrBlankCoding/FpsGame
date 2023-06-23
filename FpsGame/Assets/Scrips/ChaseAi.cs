using UnityEngine;

public class ChaseAI : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float movementSpeed = 3f; // Movement speed of the AI character

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Calculate the direction from the AI character to the player character
        Vector3 direction = (player.position - transform.position).normalized;

        // Move the AI character towards the player character
        rb.MovePosition(transform.position + direction * movementSpeed * Time.deltaTime);
    }
}