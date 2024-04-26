using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelselectloader : MonoBehaviour
{
    public Image image;

    public void LoadlevelSelect()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));

    }
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(image.fillAmount == 1)
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        }
        
    }
}
