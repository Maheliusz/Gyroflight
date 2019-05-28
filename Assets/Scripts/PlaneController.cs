using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float score = 0f;
    public float health = 100f;
    //public float speed = 100f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position += Vector3.forward * Time.deltaTime; //TODO: put real movement here
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position += Vector3.left * speed * Time.deltaTime;
            rb.MovePosition(Vector3.left * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += Vector3.right * speed * Time.deltaTime;
            rb.MovePosition(Vector3.right * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.position += Vector3.up * speed * Time.deltaTime;
            rb.MovePosition(Vector3.up * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.position += Vector3.down * speed * Time.deltaTime;
            rb.MovePosition(Vector3.down * Time.deltaTime);
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
