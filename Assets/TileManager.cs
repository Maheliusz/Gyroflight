using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject mainPrefab;
    private float tileLength = 5f;
    private readonly Vector3 _tileScale = new Vector3(1f, 1f, 1f);
    private float _distanceTravelled = 0;
    public float currentSpeed;
    
    public static float BLOCK_SPEED = 4f;
    public static float TILE_MAX_DISTANCE = 100f;

    void Start()
    {
        currentSpeed = BLOCK_SPEED;
        for (int i = 0; i < 15; i++)
        {
            SpawnTile(0, new Vector3(0, 0, i*10));
        }
    }

    void Update()
    {
        currentSpeed = modifySpeed(currentSpeed);
        if (_distanceTravelled >= tileLength)
        {
            _distanceTravelled = 0;
            SpawnTile(0, new Vector3(0,0,80));
        }
        else
        {
            _distanceTravelled += Time.deltaTime * BLOCK_SPEED;
        }
    }

    private float modifySpeed(float currentSpeed)
    {
        return currentSpeed*=(1);
    }

    private void SpawnTile(int prefabPos = 0, Vector3 pos = default(Vector3))
    {
        GameObject tile;
        tile = Instantiate(mainPrefab) as GameObject;
        tile.transform.SetParent(transform);
        tile.transform.localPosition = pos;
        tile.transform.localScale = _tileScale;
    }
}