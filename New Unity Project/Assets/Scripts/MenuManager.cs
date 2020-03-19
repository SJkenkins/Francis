using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuGroup;

    public bool menuobj = false;
  

    public void ActivateOrDisableMenuGroup()
    {
       

        if (menuobj == false)
        {
            ActivateMenu();
        }

        else if (menuobj == true)
        {
            DisableMenu();
        }

        menuobj = !menuobj;
    }


    public void ActivateMenu()
    {
        menuGroup.SetActive(true);
        Time.timeScale = 0;


    }

    public void DisableMenu()
    {
        menuGroup.SetActive(false);
        Time.timeScale = 1;

        


    }

    public void QuitGame()
    {
        Application.Quit();

    }

    
}
