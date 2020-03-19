using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyController : MonoBehaviour
{
    public float distance;
    public bool tuto;
    public GameObject Player;
    public GameObject prefabennemi;
    public Transform Joueur;
    public float spawnposx;
    public float spawnposy;
    public float spawnposz;
    public Animator animator;
    public Animator animatortrans;
    public Camera camera;



    // Start is called before the first frame update
    void Start()
    {
        spawnposx = Player.transform.position.x;
        spawnposy = Player.transform.position.y;
        spawnposz = -2.382413f;
        SpawnFX();
    }

   

    void Update()
    {
        
        distance = Vector3.Distance(Joueur.position, transform.position);
        
        DetectDeath();


        if (tuto == true)
        {
            ShakeStuff();
        }
    }

    public void SpawnFX()
    {
        Instantiate(prefabennemi, transform.position, Quaternion.identity);
        
        
    }

    public void ShakeStuff()
    {

        if (tuto == true) { 
            if (distance >= 12 && distance <= 15)
            {

                camera.gameObject.GetComponent<CameraManager>().Shaking(Mathf.Abs((-10 - distance) / 150), 0.1f);

            }
            else if (distance >= 7 && distance < 12)
            {

                camera.gameObject.GetComponent<CameraManager>().Shaking(Mathf.Abs((-10 - distance) / 80), 0.1f);

            }
            else if(distance >= 5 && distance < 7)
            {

                camera.gameObject.GetComponent<CameraManager>().Shaking(Mathf.Abs((-10 - distance) / 50), 0.1f);

            }
            else if (distance >= 2 && distance < 5)
            {

                camera.gameObject.GetComponent<CameraManager>().Shaking(Mathf.Abs((-10 - distance) / 30), 0.1f);

            }
        }

    }

    public void DetectDeath()
    {
        

        if (distance < 1.8) {

            StartCoroutine(die());

        }
    }

    public IEnumerator die()
    {
        if (tuto == false)
        {
            Player.gameObject.GetComponent<PlayerControler>().SpawnFX();
            Player.SetActive(false);
            yield return new WaitForSeconds(0.6f);

            Player.transform.position = new Vector3(spawnposx, spawnposy, spawnposz);

            Player.SetActive(true);
            animator.SetFloat("Speed", 0);
        }

        else if (tuto == true) {

            Player.gameObject.GetComponent<PlayerControler>().SpawnFX();
            Player.SetActive(false);
            yield return new WaitForSeconds(0.6f);

            Player.transform.position = new Vector3(spawnposx, spawnposy, spawnposz);

            Player.SetActive(true);
            animator.SetFloat("Speed", 0);


        }
    }
}

   