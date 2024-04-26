using UnityEngine;

public class AttachToObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform attachPoint;
    private bool isAttached = false;
    private bool isAttachPointOccupied = false; // Add a variable to track if the attach point is already occupied

    private void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the tag "Player" and if this object isn't already attached
        if (other.CompareTag("Player") && !isAttached && !isAttachPointOccupied) // Check if attach point is not already occupied
        {
            // Get the player object
            GameObject player = other.gameObject;

            // Find the attach point named "AttachPoint" among player's children
            attachPoint = player.transform.Find("AttachPoint");

            // If the attach point is found
            if (attachPoint != null)
            {
                // Mark the attach point as occupied
                isAttachPointOccupied = true;

                // Mark as attached
                isAttached = true;
            }
            else
            {
                Debug.LogError("AttachPoint not found on the player object.");
            }
        }
    }

    private void FixedUpdate()
    {
        // If attached, move the object to follow the attach point
        if (isAttached && attachPoint != null)
        {
            transform.position = attachPoint.position;
            transform.rotation = attachPoint.rotation;
        }

        if(transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }

    // Add a method to release the attach point
    public void ReleaseAttachPoint()
    {
        isAttachPointOccupied = false;
        isAttached = false;
    }

    private void OnDestroy()
    {
        // Release the attach point when the object is destroyed
        ReleaseAttachPoint();
    }
}
