using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlaneController : MonoBehaviour
{
    public float score = 0f;
    public float health = 100f;
    public float forceCoeffecient = 20f;
    private Rigidbody rb;

    public Camera camera;

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
        var rotation = camera.transform.rotation;
        rb.AddForce(Vector3.left* forceCoeffecient * rotation.z + Vector3.right*forceCoeffecient*rotation.y);
        rb.AddForce(Vector3.down * forceCoeffecient * rotation.x);
        transform.rotation = rotation;
    }

    private void ServeWithArrows()
    {
        //this.transform.position += Vector3.forward * Time.deltaTime; //TODO: put real movement here
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * forceCoeffecient);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * forceCoeffecient);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.up * forceCoeffecient);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.down * forceCoeffecient);
        }
    }

    public void DealDamage(float amount)
    {
        health -= amount;
    }

    public void Heal(float amount)
    {
        health += amount;
    }

    public void AddScore(float amount)
    {
        score += amount;
    }

    public void Kill()
    {
        health = -1f;
    }
}