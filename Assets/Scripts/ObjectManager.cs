using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject[] Bonuses;
    public GameObject[] Obstacles;

    public bool RandomX = false;
    public float chanceForPlacement = 0.5f;
    private Vector3 playerLocation;
    // Start is called before the first frame update
    void Start()
    {
        playerLocation = GameObject.Find("Plane1").transform.position;
        SpawnItem(playerLocation);
    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = GameObject.Find("Plane1").transform.position;
        SpawnItem(playerLocation);
    }

    void SpawnItem(Vector3 playerLocation)
    {
        float placementRoll = Random.Range(0f, 1f);
        Debug.Log("Rolled");
        if (placementRoll < 0.25f)
        {
            Debug.Log("Placed obstacle");
        }
        else if (placementRoll < 0.5f)
        {
            Debug.Log("Placed bonus");
        }
    }

    void CreateObject(Vector3 position, GameObject prefab)
    {
        position += new Vector3(Random.Range(-Constants.DeltaX, Constants.DeltaX), Random.Range(-Constants.DeltaY, Constants.DeltaY), 0);
        Instantiate(prefab, position, Quaternion.identity);
    }
}
