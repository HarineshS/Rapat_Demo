using UnityEngine;

public class AttachToObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isAttached = false;

    private void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the tag "Player" and if this object isn't already attached
        if (other.CompareTag("Player") && !isAttached)
        {
            // Get the player object
            GameObject player = other.gameObject;

            // Find the attach point named "AttachPoint" among player's children
            Transform attachPoint = player.transform.Find("AttachPoint");

            // If the attach point is found
            if (attachPoint != null)
            {
                // Attach this object to the attachPoint
                transform.parent = attachPoint;
                // Reset local position and rotation to maintain relative positioning
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
                // Disable the Rigidbody2D component
                rb.simulated = false;
                // Mark as attached
                isAttached = true;
            }
            else
            {
                Debug.LogError("AttachPoint not found on the player object.");
            }
        }
    }
}
