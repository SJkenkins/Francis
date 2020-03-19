using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public Transform target;
    public float speed = 0.02f;
    public float startPosZ;
	public float endPosZ;
	public float curPosZ;
    public float shakeamount;
    public float shakeposx;
    public float shakeposy;

    public KeyCode camkey;
	
    void Start()
    {
        startPosZ = transform.position.z;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(3, 2, curPosZ), speed); ;
        shakeposx = transform.position.x;
        shakeposy = transform.position.y;
    }
	
	void Update()
	{
		if(Input.GetKey(camkey))
		{
			curPosZ = endPosZ ;
		}
		
		else {
			curPosZ = startPosZ ;
		}
	}

    public void Shaking(float amount, float length)
    {
        shakeamount = amount;
        InvokeRepeating("StartShaking", 0, 0.01f);
        Invoke("StopShaking", length);
    }

    void StartShaking()
    {
        if (shakeamount > 0)
        {
            Vector3 position = transform.position;

            float shakex = Random.value * shakeamount * 2 - shakeamount;
            float shakey = Random.value * shakeamount * 2 - shakeamount;

            position.x += shakex;
            position.y += shakey;

            transform.position = position;
        }
    }

    void StopShaking()
    {
        CancelInvoke("StartShaking");
        transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(3, 2, curPosZ), speed); ;
    }

}
