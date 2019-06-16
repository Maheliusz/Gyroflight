using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class BasicTerrainGenerator : MonoBehaviour
{
    public GameObject[] treePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        var vertices = mesh.vertices;
        for (var i = 0; i < 3; i++)
        {
            var spawnPoint = transform.TransformPoint(vertices[i]);
            var q = Random.Range(0, vertices.Length);
            spawnPoint = transform.TransformPoint(vertices[q]);
            if (spawnPoint.y > 2)
            {
                spawnPoint.y = spawnPoint.y - 1f;
                var instantiate = Instantiate(treePrefabs[0], spawnPoint, transform.rotation);
                instantiate.transform.parent = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}