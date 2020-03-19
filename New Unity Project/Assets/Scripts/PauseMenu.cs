using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameispaused = false;
    public GameObject PauseMenuUi;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (gameispaused) {
                Debug.Log("Resume");
                Resume();
            }
            else {
                Debug.Log(gameispaused);
                Pause();
            }

        }
    }

    public void Resume()
    {
        gameispaused = false;
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        

    }

    void Pause()
    {
        gameispaused = true;
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        

    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        gameispaused = false;
        Debug.Log("Quit");
        Application.Quit();

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        gameispaused = false;
        SceneManager.LoadScene("Menu");

    }

}
