using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextDeclencher : MonoBehaviour
{

    public Dialogue dialogue;
    public GameObject Character;
    public bool dash;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (dash == true)
            {
                if(Character.GetComponent<PlayerControler>().power == 2) 
                {
                    
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("Texte");
                    FindObjectOfType<TextManager>().StartDialogue(dialogue);
                    Destroy(gameObject);
                }

            }
            else
            {
                Debug.Log("Texte");
                FindObjectOfType<TextManager>().StartDialogue(dialogue);
                Destroy(gameObject);
            }
        }
    }



}
