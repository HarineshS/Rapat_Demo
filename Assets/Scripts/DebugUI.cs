using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugUI : MonoBehaviour
{
    public TextMeshProUGUI moveSpeedText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI timerText;
    public RandomSpawner randomSpawner;
    public GameObject GameOverPanel;

    private void Awake()
    {
        Time.timeScale =1;
        GameOverPanel.SetActive(false);
    }

    private void Update()
    {
        // Check if Platform.Instance is not null and moveSpeedText is assigned
        if (PlatformMovement.Instance != null && moveSpeedText != null && healthText != null)
        {
            // Update the move speed text with the current move speed of the platform
            moveSpeedText.text = "Move Speed: " + PlatformMovement.Instance.MoveSpeed.ToString("F2");
            healthText.text = "Health: " + PlatformMovement.Instance.HealthUpdate.ToString("F2");
            timerText.text = "Timer: " + randomSpawner.timeRemaining.ToString("F2");

            if(randomSpawner.timeRemaining == 0f)
            {
                Time.timeScale = 0;
                GameOverPanel.SetActive(true);
            }



            
        }
        
    }

    

    
}
