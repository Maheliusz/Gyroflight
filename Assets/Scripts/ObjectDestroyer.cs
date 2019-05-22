using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyObject", LifeTime);
    }

    void DestroyObject()
    {
        if (GameManager.Instance.GameState != GameState.Dead)
            Destroy(gameObject);
    }

    public float LifeTime = 10f;
}
