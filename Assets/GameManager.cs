// GameManager.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton pattern

    public PlayerData playerData; // Reference to the PlayerData scriptable object

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Example method to get the player's level
    public int GetPlayerLevel()
    {
        return playerData.currentLevel;
    }


    public void AdvanceToNextLevel()
    {
        if(playerData.currentLevel == SceneManager.GetActiveScene().buildIndex - 1)
        {
            playerData.currentLevel++;

        }
        
        
    }
}
