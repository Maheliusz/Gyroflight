using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public float score = 0f;
    public float health = 100f;
    public Slider healthSlider;
    public Text scoreText;
    public GameObject planeHolder;

    private void Update()
    {
        if (health <= 0)
        {
            GameManager.Instance.Die();
            this.gameObject.GetComponent<UIScript>().PlayerDied();
            planeHolder.GetComponent<PlaneController>().StopMovement();
        }
        scoreText.text = Mathf.RoundToInt(score).ToString();
        healthSlider.value = health;
    }

    public void DealDamage(float amount)
    {
        health -= amount;
    }

    public void Heal(float amount)
    {
        health = Mathf.Min(100, health + amount);
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
