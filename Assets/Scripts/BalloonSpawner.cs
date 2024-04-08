using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab; // Prefab of the balloon object
    public float spawnRate = 1f; // Balloons spawn every 1 second (adjust as needed)
    public float spawnHeight = -18f; // Balloons spawn from this height
    public float moveSpeed = 2f; // Speed at which balloons move upwards
    public Transform platformTransform; // Transform of the platform object (reference)

    private float nextSpawnTime = 0f;

    void Start()
    {
        nextSpawnTime = Time.time + spawnRate; // Set initial spawn time
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnBalloon();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnBalloon()
    {
        // Create a new balloon object from the prefab
        GameObject balloon = Instantiate(balloonPrefab, new Vector3(Random.Range(-1.6f, 1.6f), spawnHeight, 0), Quaternion.identity);

        // Move the balloon upwards over time
        //balloon.GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the balloon collides with the platform
        if (collision.gameObject.transform == platformTransform)
        {
            // Destroy the balloon on collision (simulates bursting)
            Destroy(collision.gameObject);
        }
    }
}

