using UnityEngine;

public class Balloon : MonoBehaviour
{

    
    // This method is called when a collision occurs
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Destroy the balloon GameObject
            
            // Increase Score Here
            PlatformMovement.Instance.HealthUpdate -= 10f;
            PlatformMovement.Instance.IncreaseMoveSpeedByPercentage(-5f);
            RandomSpawner.Instance.reduceTime(10f);

            Destroy(gameObject);
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
