using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PipeType
{
    Red,Blue,Green,Yellow,
}
public class PipeScript : MonoBehaviour
{
    public PipeType pipeType;
    
    
    // private IEnumerator OnTriggerStay2D(Collider2D other) 
    // {
    //     if (other.gameObject.CompareTag("Gift"))
    //     {

    //         Debug.LogWarning("Destroying");
    //         //Destroy the balloon GameObject
    //         Destroy(other.gameObject);
    //         //Increase Score Here
    //     }
        
    // }

    private void OnTriggerStay2D(Collider2D other) 
    {
        // Check if the collided GameObject has the "Gift" tag
        if (other.gameObject.CompareTag("Gift"))
        {
            // Get the name of the collided GameObject
            string gameObjectName = other.gameObject.name;

            // Check the name and extract color information
            if (gameObjectName.Contains("Red") && pipeType == PipeType.Red)
            {
                Debug.LogWarning("Destroying Red Gift");
                Destroy(other.gameObject);
                // Perform actions specific to red gift
            }
            else if (gameObjectName.Contains("Blue")&& pipeType == PipeType.Blue)
            {
                Debug.LogWarning("Destroying Blue Gift");
                Destroy(other.gameObject);
                // Perform actions specific to blue gift
            }
            else if (gameObjectName.Contains("Green")&& pipeType == PipeType.Green)
            {
                Debug.LogWarning("Destroying Green Gift");
                Destroy(other.gameObject);
                // Perform actions specific to blue gift
            }
            else if (gameObjectName.Contains("Yellow")&& pipeType == PipeType.Yellow)
            {
                Debug.LogWarning("Destroying Yellow Gift");
                Destroy(other.gameObject);
                // Perform actions specific to blue gift
            }
            
        }
    }

}
