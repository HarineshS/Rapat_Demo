using UnityEngine;

public class Balloon : MonoBehaviour
{
    // This method is called when a collision occurs
  

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Destroy the balloon GameObject
            Destroy(gameObject);
            // Increase Score Here
        }
        
    }

    private void Update() 
    {
        if(transform.position.y > 15f)
        {
            Destroy(gameObject);
        }
        
    }
}
