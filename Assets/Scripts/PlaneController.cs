using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlaneController : MonoBehaviour
{
    public float forceCoeffecient = 10f;
    private Rigidbody rb;

    public Camera camera;
    private bool canMove = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
//        ServeWithArrows();
        ServeWithVR();
    }

    private void ServeWithVR()
    {
        if (!canMove) return;
        var rotation = camera.transform.rotation;
        rb.AddForce(Vector3.left* forceCoeffecient * rotation.z + Vector3.right*forceCoeffecient*rotation.y);
        rb.AddForce(Vector3.down * forceCoeffecient * rotation.x);
        transform.rotation = rotation;
        //rb.AddForce(Vector3.left* forceCoeffecient * rotation.z + Vector3.right*forceCoeffecient / 100*rotation.y);
        
    }

    private void ServeWithArrows()
    {
        //this.transform.position += Vector3.forward * Time.deltaTime; //TODO: put real movement here
        if (Input.GetKey(KeyCode.LeftArrow) && canMove)
        {
            rb.AddForce(Vector3.left * forceCoeffecient);
        }
        if (Input.GetKey(KeyCode.RightArrow) && canMove)
        {
            rb.AddForce(Vector3.right* forceCoeffecient);
        }
        if (Input.GetKey(KeyCode.UpArrow) && canMove)
        {
            rb.AddForce(Vector3.up* forceCoeffecient);
        }
        if (Input.GetKey(KeyCode.DownArrow) && canMove)
        {
            rb.AddForce(Vector3.down * forceCoeffecient);
        }
    }

    public void StopMovement()
    {
        rb.velocity = Vector3.zero;
        canMove = false;
    }
}