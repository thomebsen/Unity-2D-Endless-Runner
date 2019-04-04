using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    float rndNum;
    public GameObject powerUp;
    [Range(0, 100)] public float spawnChance;
    // Start is called before the first frame update
    void Start()
    {
        rndNum = Random.Range(0, 100);
        if (rndNum <= spawnChance)
        {
            print("spawned powerup!");            
            Instantiate(powerUp, transform.position, Quaternion.identity);
        }
    }
}
