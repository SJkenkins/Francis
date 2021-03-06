﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionTuto : MonoBehaviour
{
    public GameObject Player;
    public Animator Animatortrans;
    public GameObject Canvas;
    public GameObject Ennemy;
    public Camera Camera;
    public bool tuto;
    public bool haut;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // On vérifie si on entre en contact avec le player, puis on lance la fin du niveau
        if (collision.transform.CompareTag("Player"))
        {
            // La transition est particulière pour le tuto, donc on crée un cas spécifique avec le bool tuto --> on peut créer d'autres bool pour faire d'autres animations
            //spécifiques si besoin
            if(tuto == true) {
                
                Camera.GetComponent<AudioSource>().Stop();
                Canvas.SetActive(true);
                Player.gameObject.GetComponent<PlayerControler>().SpawnFX();
                Player.SetActive(false);
                Animatortrans.SetTrigger("Transition");
                
            }

            if (haut == true)
            {
                //Pour gérer les fins multiples, on va au niveau N+2 si on prend le chemin du haut, N+1 si on prend le chemin du bas.
                Camera.GetComponent<AudioSource>().Stop();
                Canvas.SetActive(true);
                Player.gameObject.GetComponent<PlayerControler>().SpawnFX();
                Player.SetActive(false);
                Animatortrans.SetTrigger("Transition");
                Player.SetActive(true);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }

            else
            {
                //L'animation de base, on désactive le player, et on lance le fade
                
                Camera.GetComponent<AudioSource>().Stop();
                Canvas.SetActive(true);
                Player.SetActive(false);
                Destroy(gameObject);
                Animatortrans.SetTrigger("Transition");
            }

            

        }
    }
    // Une fois la transition "cinématique" terminée, on change de scène 
    public void OnFadeComplete()
    {
       
            Debug.Log("bas");
            Player.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
