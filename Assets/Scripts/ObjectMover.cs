using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectMover : MonoBehaviour
{
    public Vector3 directionOfMovement = Vector3.down;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(directionOfMovement * Time.deltaTime);
    }
}
