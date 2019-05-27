using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Tile : MonoBehaviour
{
    private float _distanceTravelled = 0;


    // Start is called before the first frame update
    void Start()
    {
    
    }

    

// Update is called once per frame
    void Update()
    {
        this.transform.Translate(-Vector3.forward * TileManager.BLOCK_SPEED * Time.deltaTime);
        _distanceTravelled += TileManager.BLOCK_SPEED * Time.deltaTime;
        if (_distanceTravelled > TileManager.TILE_MAX_DISTANCE)
        {
            Destroy(gameObject);
        }
    }
}