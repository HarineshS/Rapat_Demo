using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        // Check the tag of the GameObject
        if (gameObject.CompareTag("Baloon"))
        {
            // Move the GameObject upwards
            transform.Translate(speed * Time.deltaTime * Vector2.up);
        }
        else if (gameObject.CompareTag("Star"))
        {
            // Move the GameObject downwards
            transform.Translate(speed * Time.deltaTime * Vector2.down);
        }
    }
}
