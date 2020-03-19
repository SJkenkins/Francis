using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    public Transform target;
    public float speed = 0.02f;
    public float startPosZ;
    public float endPosZ;
    public float curPosZ;

    public KeyCode camkey;

    void Start()
    {
        startPosZ = transform.position.z;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(3, 2, curPosZ), speed); ;
    }

    void Update()
    {
        if (Input.GetKey(camkey))
        {
            curPosZ = endPosZ;
        }

        else
        {
            curPosZ = startPosZ;
        }
    }

}
