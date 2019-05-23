using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public float health = 100.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        this.health -= damage;
    }

    public bool IsAlive()
    {
        return health > 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        //TODO
    }
}
