using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Tile : MonoBehaviour
{
    private float distanceTravelled = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-Vector3.forward*TileManager.BLOCK_SPEED * Time.deltaTime);
        distanceTravelled += TileManager.BLOCK_SPEED * Time.deltaTime;
        if (distanceTravelled > TileManager.TILE_MAX_DISTANCE)
        {
            Destroy(gameObject);
        }
    }
}
