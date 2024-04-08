using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public float yPosition;

    // The range within which the prefab will be instantiated on the x-axis
    public float minX;
    public float maxX;

    // Interval between spawns
    public float spawnInterval = 1f;

    void Start()
    {
        // Start the coroutine for continuous spawning
        StartCoroutine(SpawnCoroutine());
    }

    public IEnumerator SpawnCoroutine()
    {
        // Infinite loop for continuous spawning
        while (true)
        {
            // Generate a random x position within the specified range
            float randomX = Random.Range(minX, maxX);

            // Create a Vector3 to store the position
            Vector3 spawnPosition = new Vector3(randomX, yPosition, 0f);

            // Instantiate the prefab at the random position
            Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);

            // Wait for the specified interval before spawning the next object
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
