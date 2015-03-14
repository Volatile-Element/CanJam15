﻿using UnityEngine;
using System.Collections;

public class CharControler : MonoBehaviour {

    //CharacterController characterController;
    public float speed, rotSpeed;
    Rigidbody rb;

	// Use this for initialization
	void Start () {

        //characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    void LateUpdate()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddRelativeForce(new Vector3(speed, 0, 0));
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddRelativeForce(new Vector3(-speed, 0, 0));
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            gameObject.transform.Rotate(Vector3.up, rotSpeed); 
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            gameObject.transform.Rotate(Vector3.up, -rotSpeed);
        }
    }
}