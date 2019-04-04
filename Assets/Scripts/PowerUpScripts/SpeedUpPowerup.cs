using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPowerup : MonoBehaviour
{
    public GameObject player;
    public GameObject particles;

    public float speedDuration = 10f;

    private bool isTrigger = false;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!isTrigger)
        {
            if (col.tag == "Player")
            {
                isTrigger = true;
                ChangeRunSpeed(player.transform);
                GameObject effectIns = (GameObject)Instantiate(particles, transform.position, transform.rotation); //Spawn a particle effect     
                Destroy(effectIns, 2f); //Destroy bullet shatter effect
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (isTrigger)
        {
            if (col.tag == "Player")
            {
                isTrigger = false; //Allows for another object to be struck by this one
            }

        }
    }


    void ChangeRunSpeed(Transform player)
    {
        PlayerMovement p = this.player.GetComponent<PlayerMovement>();

        if (p != null)
        {
           p.StartCoroutine(p.SpeedUp(speedDuration));
        }
    }
}
