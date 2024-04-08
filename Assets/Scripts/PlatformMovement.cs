using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Adjust this speed to control how fast the player follows the cursor
    public float followSpeed = 5f;

    private bool isClicked = false;

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position to detect if it hits the player
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // If the ray hits the player, set isClicked to true
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isClicked = true;
            }
        }

        // Check for mouse release
        if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
        }

        // If the player is clicked, make it follow the cursor
        if (isClicked)
        {
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z; // Ensure z position remains unchanged
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
