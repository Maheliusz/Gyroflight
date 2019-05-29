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
    public float score = 0f;
    public float health = 100f;
    public float forceCoeffecient = 20f;
    public Slider healthSlider;
    public Text scoreText;
    private Rigidbody rb;
    private bool canMove = true;

    public Camera camera;
    public GameObject CamContainer;

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
        rb.AddForce(Vector3.left* forceCoeffecient * rotation.z + Vector3.right*forceCoeffecient / 100*rotation.y);
        rb.AddForce(Vector3.down * forceCoeffecient * rotation.x);
        
    }

    private void ServeWithArrows()
    {
        //this.transform.position += Vector3.forward * Time.deltaTime; //TODO: put real movement here
        if (Input.GetKey(KeyCode.LeftArrow) && canMove)
        {
//            transform.position += Vector3.left * speed * Time.deltaTime;
//            rb.MovePosition(Vector3.left * Time.deltaTime);
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
        if (health <= 0)
        {
            GameManager.Instance.Die();
            this.gameObject.GetComponent<UIScript>().PlayerDied();
            this.rb.velocity = Vector3.zero;
            this.canMove = false;
        }
        scoreText.text = Mathf.RoundToInt(score).ToString();
        healthSlider.value = health;
    }

    private void OnTriggerEnter(Collider other)
    {
    }

    public void DealDamage(float amount)
    {
        health -= amount;
    }

    public void Heal(float amount)
    {
        health = Mathf.Min(100, health+amount);
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
