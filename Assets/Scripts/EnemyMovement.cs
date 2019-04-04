using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject levelHandler;
    private Rigidbody2D rb;
    public Vector3 offset;
    private float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = player.transform.position + offset;
        moveSpeed = player.GetComponent<PlayerMovement>().walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y); //Move forward

        if(transform.position.x > player.transform.position.x + (-offset.x))
        {
            levelHandler.GetComponent<LevelLoader>().GameOver();
        }
    }
}
