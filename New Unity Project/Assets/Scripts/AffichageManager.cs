using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffichageManager : MonoBehaviour
{
    public float distance;
    public Transform Joueur;
    public GameObject Stuff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Joueur.position, transform.position);
    }

    void Affichage()
    {
        if (distance >= 7)
        {
            Stuff.SetActive(false);
            Debug.Log("à l'ancienne");
        }
        else{

            Stuff.SetActive(true);
        }
    }
}
