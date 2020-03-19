using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    public GameObject playerRespawn;
    public Animator animator;
    public float spawnposx;
    public float spawnposy;
    public float spawnposz;

    void Start()
    {
    spawnposx = playerRespawn.transform.position.x;
    spawnposy = playerRespawn.transform.position.y;
    spawnposz = -2.382413f;
    }
        
    

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerControler>().SpawnFX();
            GetComponent<AudioSource>().Play();
            playerRespawn.SetActive(false);
            yield return new WaitForSeconds(0.6f);
            // respawn phase 
            playerRespawn.transform.position = new Vector3(spawnposx, spawnposy, spawnposz);
           
            playerRespawn.SetActive(true);
            animator.SetFloat("Speed", 0);
        }
    }
}
