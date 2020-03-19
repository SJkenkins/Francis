using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeLevel : MonoBehaviour
{
    public Animator animator;
    private int LevelToLoad;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToLevel(int LevelIndex)
    {

        LevelToLoad = LevelIndex;
        animator.SetTrigger("Fadeout");
       
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
