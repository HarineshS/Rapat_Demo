using UnityEngine;

public class FallDownSlowly : MonoBehaviour
{
    public float fallSpeed = 1f; // Adjust this to control the speed of falling
    public float fallDistance = 10f; // Adjust this to control how far the object falls

    private Rigidbody2D rb;
    private Vector2 startPosition;
    //private bool shouldFall = true; // Flag to control whether the object should fall

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.bodyType = RigidbodyType2D.Kinematic; // Set the Rigidbody to kinematic
        startPosition = rb.position;
    }

    // private void FixedUpdate()
    // {
    //     // Check if the object should continue falling
    //     if (!shouldFall)
    //         return;

    //     // Calculate the new Y position based on the fall speed and time
    //     float newY = startPosition.y - (fallDistance * Mathf.Clamp01(Time.time * fallSpeed));

    //     // Set the velocity to make the object fall towards the new position
    //     Vector2 velocity = (new Vector2(0f, newY) - rb.position) / Time.fixedDeltaTime;
    //     rb.velocity = velocity;
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the trigger condition is met (e.g., collision with another object)
        if (other.CompareTag("Player"))
        {
           rb.bodyType = RigidbodyType2D.Kinematic; 
            // Set the flag to stop falling
            //shouldFall = false;
        }
    }
}
