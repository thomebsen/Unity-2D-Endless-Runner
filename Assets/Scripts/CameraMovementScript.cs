using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;
    public float allowedOffset = 15; //Deathzone

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }
    void Update()
    {
        if (transform.position.x < player.transform.position.x - allowedOffset)
        {
            print("ASDASD");
        }
    }
    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
