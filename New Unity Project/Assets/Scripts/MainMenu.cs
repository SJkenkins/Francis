using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void play() 
    {
        FindObjectOfType<FadeLevel>().FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
