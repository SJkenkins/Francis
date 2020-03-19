using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Powerup : MonoBehaviour
{
    
    public bool Power1;
    public bool Power2;
    public bool Power3;
    public bool Tuto;
    public bool Plateformes;

    public GameObject Character;
    public GameObject Affichage;
    public GameObject DeadZone;
    public GameObject Plateforme;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {

            if(Plateformes == true)
            {

                Plateforme.SetActive(true);

            }
            DeadZone.GetComponent<DeathZone>().spawnposx = transform.position.x;
            DeadZone.GetComponent<DeathZone>().spawnposy = transform.position.y;
            

            if (Power1 == true) { 

            Character.GetComponent<PlayerControler>().power = 1;
            


            Destroy(gameObject);

            


            }

            if (Power2 == true)
            {

                Character.GetComponent<PlayerControler>().power = 2;
                Destroy(gameObject);

            }

            if (Power3 == true)
            {

                Character.GetComponent<PlayerControler>().power = 3;
                Destroy(gameObject);

            }

            if (Tuto == true) {

                Affichage.SetActive(true);

            }

        }
    }

    

}
