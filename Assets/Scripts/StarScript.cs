using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update() 
    {
        if(transform.position.y < -15f)
        {
            Destroy(gameObject);
        }

        
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Destroy the balloon GameObject
            
            PlatformMovement.Instance.IncreaseMoveSpeedByPercentage(10f);
            PlatformMovement.Instance.HealthUpdate += 15f;
            RandomSpawner.Instance.addTime(20f);
            Destroy(gameObject);
        }
        
    }
}
