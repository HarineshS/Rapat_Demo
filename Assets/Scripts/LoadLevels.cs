using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour
{

    public void Level1()
    {
        SceneManager.LoadScene(2);

    }
   
    public void Level2()
    {
        SceneManager.LoadScene(3);

    }
    public void Level3()
    {
        SceneManager.LoadScene(4);

    }
    public void Level4()
    {
        SceneManager.LoadScene(4);

    }
    public void Level5()
    {
        SceneManager.LoadScene(4);

    }
     public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void startTime()
    {
        Time.timeScale =1f;
    }
    public void Levelselect()
    {
        SceneManager.LoadScene(1);
    }

    public void nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Pause()
    {
        Time.timeScale = 0;

    }

    public void Resume()
    {
        Time.timeScale = 1;
        
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    
    




}
