using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VRCameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    public VRCameraController()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
       offset = new Vector3(0,0,-2f);
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void LateUpdate ()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        
    }
}
