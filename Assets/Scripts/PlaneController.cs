using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    public float score = 0f;
    public float health = 100f;
    public float forceCoeffecient = 20f;
    public Slider healthSlider;
    public Text scoreText;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(rb);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
//            transform.position += Vector3.left * speed * Time.deltaTime;
//            rb.MovePosition(Vector3.left * Time.deltaTime);
            rb.AddForce(Vector3.left * forceCoeffecient);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
//            transform.position += Vector3.right * speed * Time.deltaTime;
//            rb.MovePosition(Vector3.right * Time.deltaTime);
            rb.AddForce(Vector3.right* forceCoeffecient);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
//            transform.position += Vector3.up * speed * Time.deltaTime;
//            rb.MovePosition(Vector3.up * Time.deltaTime);
            rb.AddForce(Vector3.up* forceCoeffecient);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
//            transform.position += Vector3.down * speed * Time.deltaTime;
//            rb.MovePosition(Vector3.down * Time.deltaTime);
            rb.AddForce(Vector3.down * forceCoeffecient);
        }
        if (health <= 0)
        {
            GameManager.Instance.Die();
            Destroy(this);
        }
        //scoreText.text = Mathf.RoundToInt(score).ToString();
        //healthSlider.value = health;
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
