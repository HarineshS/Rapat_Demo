using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpawner : MonoBehaviour
{
    // Arrays for each color of spawn points and their corresponding prefabs
    public GameObject[] redPrefabs;
    public Transform[] redSpawnPoints;
    public GameObject[] yellowPrefabs;
    public Transform[] yellowSpawnPoints;
    public GameObject[] greenPrefabs;
    public Transform[] greenSpawnPoints;
    public GameObject[] bluePrefabs;
    public Transform[] blueSpawnPoints;
    

    public float minSpawnInterval = 1f; // Minimum time between spawns
    public float maxSpawnInterval = 3f; // Maximum time between spawns

    public float levelDuration = 60f; // Total duration of the level in seconds
    private float elapsedTime = 0f; // Elapsed time in the level
    public float timeRemaining; // Time remaining in the level

    public static RandomSpawner Instance { get; private set; }



    public void reduceTime(float value)
    {
        elapsedTime +=value;
    }
    public void addTime(float value)
    {
        elapsedTime -=value;
    }


    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple Spawners instances detected. Make sure there's only one in the scene.");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnRoutine());
    }

    void Update()
    {
        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate the time remaining
        timeRemaining = Mathf.Max(0f, levelDuration - elapsedTime);

        // Update the timer display
        UpdateTimerDisplay();
    }

    IEnumerator SpawnRoutine()
    {
        while (elapsedTime < levelDuration)
        {
            // Choose a random color
            GameObject[] chosenPrefabs;
            Transform[] chosenSpawnPoints;

            int randomColor = Random.Range(0, 4); // 0: Red, 1: Yellow, 2: Green, 3: Blue

            switch (randomColor)
            {
                case 0:
                    chosenPrefabs = redPrefabs;
                    chosenSpawnPoints = redSpawnPoints;
                    break;
                case 1:
                    chosenPrefabs = yellowPrefabs;
                    chosenSpawnPoints = yellowSpawnPoints;
                    break;
                case 2:
                    chosenPrefabs = greenPrefabs;
                    chosenSpawnPoints = greenSpawnPoints;
                    break;
                case 3:
                    chosenPrefabs = bluePrefabs;
                    chosenSpawnPoints = blueSpawnPoints;
                    break;
                default:
                    chosenPrefabs = redPrefabs;
                    chosenSpawnPoints = redSpawnPoints;
                    break;
            }

            // Get a random spawn point index
            int randomIndex = Random.Range(0, chosenSpawnPoints.Length);
            // Get a random prefab from the chosen array
            GameObject prefabToSpawn = chosenPrefabs[Random.Range(0, chosenPrefabs.Length)];

            // Spawn the prefab at the randomly chosen spawn point
            Instantiate(prefabToSpawn, chosenSpawnPoints[randomIndex].position, Quaternion.identity);

            // Wait for a random interval before spawning the next prefab
            float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(randomInterval);
        }

        Debug.Log("Level completed!");
    }

    void UpdateTimerDisplay()
    {
        // Update the timer text
        
           
        
    }
}
