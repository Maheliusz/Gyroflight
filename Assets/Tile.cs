using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Tile : MonoBehaviour
{
    private float _distanceTravelled = 0;
    public List<Vector3> spawnPositions;
    public GameObject[] possiblePickUps;

    // Start is called before the first frame update
    void Start()
    {
        int amountOfSpawns = Random.Range(0, spawnPositions.Count-1);
        List<Vector3> chosenSpawns = new List<Vector3>();
        for (int i = 0; i < amountOfSpawns; i++)
        {
            int position = Random.Range(0, spawnPositions.Count);
            chosenSpawns.Add(spawnPositions[position]);
            spawnPositions.RemoveAt(position);
        }
        foreach (Vector3 point in spawnPositions)
        {
            GameObject pickUp = possiblePickUps[Random.Range(0, possiblePickUps.Length)];
            pickUp = Instantiate(pickUp) as GameObject;
            Vector3 spawnPoint = new Vector3(point.x, point.y, this.transform.position.z);
            pickUp.transform.SetParent(transform);
            pickUp.transform.position = spawnPoint;
        }
    }

    

// Update is called once per frame
    void Update()
    {
        //float speed = this.transform.parent.gameObject.GetComponent<TileManager>().currentSpeed;
        this.transform.Translate(-Vector3.forward * TileManager.BLOCK_SPEED * Time.deltaTime);
        _distanceTravelled += TileManager.BLOCK_SPEED * Time.deltaTime;
        if (_distanceTravelled > TileManager.TILE_MAX_DISTANCE)
        {
            Destroy(gameObject);
        }
    }

}