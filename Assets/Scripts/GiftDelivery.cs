using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GiftDelivery : MonoBehaviour
{
    public GameObject[] pipePrefabs; // Array of pipe prefabs (left and right sides)
    public GameObject[] giftPrefabs; // Array of gift prefabs (matching pipe colors)
    public Transform platformTransform; // Transform of the platform object
    public float spawnIntervalMin = 5f; // Minimum spawn interval for gifts (seconds)
    public float spawnIntervalMax = 6f; // Maximum spawn interval for gifts (seconds)
    public float giftMoveSpeed = 2f; // Speed at which gifts move upwards
    public float giftCatchDistance = 1f; // Distance between platform and gift for catching
    public float giftReleaseDistance = 0.5f; // Distance between gift and pipe for releasing

    private float nextSpawnTime = 0f;
    private GameObject currentGift = null;

    void Start()
    {
        nextSpawnTime = Time.time + UnityEngine.Random.Range(spawnIntervalMin, spawnIntervalMax + 0.1f);
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnGift();
            nextSpawnTime = Time.time + UnityEngine.Random.Range(spawnIntervalMin, spawnIntervalMax);
        }

        if (currentGift != null)
        {
            MoveGift();
            HandleGiftCatchRelease();
        }
    }

    void SpawnGift()
    {
        int pipeIndex = UnityEngine.Random.Range(0, pipePrefabs.Length); // Choose a random pipe

        // Create a new gift object of matching color
        GameObject gift = Instantiate(giftPrefabs[pipeIndex], pipePrefabs[pipeIndex].transform.position + new Vector3(-1f, 0f, 0f), Quaternion.identity);

        currentGift = gift;
        currentGift.GetComponent<Rigidbody2D>().velocity = new Vector2(0, giftMoveSpeed); // Move upwards
    }

    void MoveGift()
    {
        currentGift.transform.position += Vector3.up * giftMoveSpeed * Time.deltaTime;
    }

    void HandleGiftCatchRelease()
    {
        float distanceToPlatform = Vector2.Distance(currentGift.transform.position, platformTransform.position);

        // Check if gift is close enough to platform to be caught
        if (distanceToPlatform <= giftCatchDistance)
        {
            currentGift.transform.parent = platformTransform; // Attach gift to platform
            currentGift.GetComponent<Rigidbody2D>().isKinematic = true; // Stop gift movement
        }
        else
        {
            currentGift.transform.parent = null; // Detach gift from platform (if previously caught)
            currentGift.GetComponent<Rigidbody2D>().isKinematic = false; // Allow gift movement
        }

        // Check if gift is close enough to matching pipe on right side for release
        int matchingPipeIndex = Array.IndexOf(pipePrefabs, currentGift.GetComponent<Renderer>().material); // Find matching pipe based on gift material
        if (matchingPipeIndex >= 0)
        {
            Transform matchingPipeTransform = pipePrefabs[matchingPipeIndex].transform;
            float distanceToPipe = Vector2.Distance(currentGift.transform.position, matchingPipeTransform.position);
            if (distanceToPipe <= giftReleaseDistance)
            {
                Destroy(currentGift); // Release gift (disappear)
                currentGift = null;
            }
        }
    }
}

