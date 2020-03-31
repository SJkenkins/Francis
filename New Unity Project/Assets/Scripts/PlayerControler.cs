using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Animator animator;
    public Transform transformRender;

    public int number;
    public int jumpcount;
    public int dashcount;
    public int power;
    
    public float movespeed = 1f;
    public float jumpspeed = 1f;
    public float dashspeed = 1f;
    

    public GameObject prefab;
    public GameObject prefabdash;
    public GameObject prefabdash2;
    
    public GameObject PrefabText;
    public KeyCode spawnkey;
    public Vector3 direction;

    public KeyCode rightkey;
    public KeyCode leftkey;
    public KeyCode jumpkey;
    public KeyCode fallkey;
    public KeyCode dashkey;
    public KeyCode attackkey;

    public Rigidbody2D myrigibody;

    public bool isGrounded;
    public bool isOnWallLeft = false;
    public bool isOnWallRight = false;
    public bool attackbool;
    public bool directiondroite;
    public bool LockMouvement ;
    public bool TouchingWall;
    public Ray ray;
    public Ray rayleft;
    public Ray rayright;

    public LayerMask jumplayer;
    public float fallMultiplicateur = 1.01f;
    public float freeFall = 1.01f;

    public Transform attack;

    public AudioSource tickSource;

    public bool Path ;

    void Start()
    {
        animator.SetFloat("Speed", 0);
        animator.SetFloat("Jump", 0);
        LockMouvement = false;
    }

    public void Update()
    {
        RaycastUpdate();
        SpawnUpdate();
        MoveUpdate();
        JumpUpdate();
        DashUpdate();
        StopMove();
        StopJump();
        FreeFallUpdate();
    }

    public void FixedUpdate()
    {
        FallUpdate();
        
    }

    // Sounds

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Jump")
        {
            Debug.Log("sonpowerup");
            tickSource.Play();
        }
        if (other.name == "Dash")
        {
            Debug.Log("sonpowerup");
            tickSource.Play();
        }
        if (other.name == "Jump2")
        {
            Debug.Log("sonpowerup");
            tickSource.Play();
        }        
    }

    // Detection of the ground and the walls

    void RaycastUpdate()
    {
        // Detection of the ground

        ray = new Ray(transform.position, new Vector3(0, -0.00005f, 0));
        Debug.DrawRay(ray.origin, ray.direction);

        if (Physics2D.Raycast(ray.origin, ray.direction, 1, jumplayer))
        {
            // Debug.Log(2222);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // Detection of the Walls

        rayleft = new Ray(transform.position, new Vector3(-0.00005f, 0, 0));
        rayright = new Ray(transform.position, new Vector3(0.00005f, 0, 0));


        if (Physics2D.Raycast(rayleft.origin, rayleft.direction, 1, jumplayer))
        {
            isOnWallLeft = true;
        }
        else
        {
            isOnWallLeft = false;
        }
        if (Physics2D.Raycast(rayright.origin, rayright.direction, 1, jumplayer))
        {
            isOnWallRight = true;
        }
        else
        {
            isOnWallRight = false;
        }

        //TouchingWall = Physics2D.Raycast(WallCheck.position, transform.right, wallcheckDistance);
    }

    // Jump
        
    public void JumpUpdate()
    {
        if (isGrounded == true)
        {
            

            if (jumpcount != 2)
            {
                jumpcount = 2;
                dashcount = 1;
            }
        }

        if (Input.GetKeyDown(jumpkey))
        {
            if (isGrounded == true)
            {
                myrigibody.velocity = new Vector3(myrigibody.velocity.x, jumpspeed, 0);
                jumpcount -= 1;
                GetComponent<AudioSource>().Play();
            }
            if (isGrounded == false)
            {
                if (jumpcount != 0)
                {
                    if (power == 1) 
                    {
                        GetComponent<AudioSource>().Play();
                        myrigibody.velocity = new Vector3(myrigibody.velocity.x, jumpspeed, 0);
                        jumpcount = 0;
                    }

                }

                if (isOnWallLeft == true || isOnWallRight == true)
                {
                    GetComponent<AudioSource>().Play();
                    myrigibody.velocity = new Vector3(myrigibody.velocity.x, jumpspeed, 0);
                    jumpcount -= 1;
                }
            }

        }
    }

    // Dash

    public void DashUpdate()
    {
        if (Input.GetKeyDown(dashkey))
        {
            if (power == 2)
            {
                if (dashcount == 1)
                {
                    if (isGrounded == false)
                    {
                        LockMouvement = true;



                        if (directiondroite == true)
                        {
                            StartCoroutine(DashDroite());
                        }
                        if (directiondroite == false)
                        {
                            StartCoroutine(DashGauche());
                        }
                    }
                }
            }
        }
    }

    public IEnumerator DashDroite()
    {
        Instantiate(prefabdash, transform.position, Quaternion.identity);
        myrigibody.velocity = new Vector3(myrigibody.velocity.x + dashspeed, myrigibody.velocity.y, 0);
        dashcount -= 1;
        yield return new WaitForSeconds(0.5f);
        LockMouvement = false;
    }

    public IEnumerator DashGauche()
    {
        Instantiate(prefabdash2, transform.position, Quaternion.identity);
        myrigibody.velocity = new Vector3(-(myrigibody.velocity.x + dashspeed), myrigibody.velocity.y, 0);
        dashcount -= 1;
        yield return new WaitForSeconds(0.5f);
        LockMouvement = false;
        Debug.Log("DashGauche");
    }


// Mouvement 
    public void MoveUpdate()
    {

        if (LockMouvement == false)
        {
            //print(sideCheckerLeftScript.IsCollidingWall());
            if (Input.GetKey(rightkey) && isOnWallRight == false)
            {
                directiondroite = true;
                myrigibody.velocity = new Vector3(movespeed, myrigibody.velocity.y, 0);
                transformRender.localScale = new Vector3(Mathf.Abs(transformRender.localScale.x), transformRender.localScale.y, transformRender.localScale.z);
                animator.SetFloat("Speed", 1);
            }

            if (Input.GetKey(leftkey) && isOnWallLeft == false)
            {
                directiondroite = false;
                myrigibody.velocity = new Vector3(-movespeed, myrigibody.velocity.y, 0);
                transformRender.localScale = new Vector3(-Mathf.Abs(transformRender.localScale.x), transformRender.localScale.y, transformRender.localScale.z);
                animator.SetFloat("Speed", 1);               
            }


        }
    }

    public void SpawnFX()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    public void SpawnUpdate()
    {
        if (Input.GetKeyDown(spawnkey))
        {
            SpawnPrefab();
        }
    }

    public void SpawnPrefab()
    {
        // Debug.Log(number);

        Instantiate(prefab);
    }

 

    void FallUpdate()
    {
        if(myrigibody.velocity.y < 0)
        {
            
            myrigibody.velocity = new Vector2(myrigibody.velocity.x, myrigibody.velocity.y*fallMultiplicateur);
        }

       
    }

    void FreeFallUpdate()
    {
        
             if (isGrounded == false)
            {
                if (Input.GetKeyUp(fallkey))
                {
                    myrigibody.velocity = new Vector2(myrigibody.velocity.x,-9);
                }

            }
        

       
    }


    void StopMove()
    {
        if (Input.GetKeyUp(rightkey))
        {
            animator.SetFloat("Speed", 0);
            


            if (isGrounded == true)
            {
                
                myrigibody.velocity = new Vector3(0, 0, 0);
                animator.SetFloat("Speed", 0);
                
            }
        }

        if (Input.GetKeyUp(leftkey))
        {
            animator.SetFloat("Speed", 0);
            if (isGrounded == true)
            {
                if (LockMouvement == true)
                {
                    LockMouvement = false;
                }
                myrigibody.velocity = new Vector3(0, 0, 0);
                animator.SetFloat("Speed", 0);
                
            }
        }
    }

    void StopJump() { 
        if(isGrounded == true)
        {
            animator.SetFloat("Jump", 0);
        }


    }

}
