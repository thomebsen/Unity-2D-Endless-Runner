using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private float moveSpeed = 0; //don't change this
    public float walkSpeed = 8f;
    public float runSpeed = 16f;
    public float jumpForce;

    private Rigidbody2D rb;

    public bool isGrounded;
    public LayerMask groundLayer;

    public Collider2D groundCol;
    public Animator myAnim;
    public GameObject playerTail;

    public bool isRunning = false;

    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = walkSpeed;
        isRunning = false; //don't run at the start of the game
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(groundCol, groundLayer); //Check if i am touching the ground
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y); //Move forward


        if (isRunning == false) { moveSpeed = walkSpeed; }
        if (isRunning == true) { moveSpeed = runSpeed; }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.y, jumpForce); //Jump
            }
        }
    }

    public IEnumerator SpeedUp(float time)
    {
        isRunning = true;
        yield return new WaitForSeconds(time);
        isRunning = false;
    }
}
