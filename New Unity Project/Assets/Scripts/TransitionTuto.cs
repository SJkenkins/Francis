using System.Collections;
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
        if (collision.transform.CompareTag("Player"))
        {
            if(tuto == true) {
                Camera.GetComponent<AudioSource>().Stop();
                Canvas.SetActive(true);
                Player.gameObject.GetComponent<PlayerControler>().SpawnFX();
                Player.SetActive(false);
                Animatortrans.SetTrigger("Transition");
            }
            else
            {
                Camera.GetComponent<AudioSource>().Stop();
                Canvas.SetActive(true);
                Player.SetActive(false);
                Destroy(gameObject);
                Animatortrans.SetTrigger("Transition");
            }

            

        }
    }

    public void OnFadeComplete()
    {
        Player.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
