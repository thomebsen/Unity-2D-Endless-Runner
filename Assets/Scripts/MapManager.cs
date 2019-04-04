using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private Transform playerTransform;
    private int amountOfChunksOnScreen = 5;
    public GameObject[] chunkPrefabs;
    public float spawnX = -80.0f;
    public float SafeZone = 40f;
    private float chunkLength = 40f;
    private int lastPrefabIndex = 0;

    //spawnX, SafeZone and chunkLength should be the same value.
    //I could fix this in the code, but I'm lazy.

    public List<GameObject> activeChunks;

    // Start is called before the first frame update
    void Start()
    {
        activeChunks = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amountOfChunksOnScreen; i++)
        {
            if (i < 2)
            {
                SpawnChunk(0);
            }
            else
            {
                SpawnChunk();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.transform.position.x - SafeZone > (spawnX - amountOfChunksOnScreen * chunkLength))
        {
            SpawnChunk();
            DeleteChunk();
        }
    }


    private void SpawnChunk(int prefabIndex = -1)
    {
        GameObject chunk;
        if(prefabIndex == -1)
        {
            chunk = Instantiate(chunkPrefabs[RandomPrefabIndex()]) as GameObject;
        } else
        {
            chunk = Instantiate(chunkPrefabs[prefabIndex]) as GameObject; 
        }
        
        chunk.transform.SetParent(transform);
        chunk.transform.position = new Vector2(1,0) * spawnX;
        spawnX += chunkLength;
        activeChunks.Add(chunk);
    }

    private void DeleteChunk()
    {
        Destroy(activeChunks[0]);
        activeChunks.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if(chunkPrefabs.Length <= 1)
        {
            return 0;
        }

        int rndIndex = lastPrefabIndex;
        while(rndIndex == lastPrefabIndex)
        {
            rndIndex = Random.Range(0, chunkPrefabs.Length);
        }

        lastPrefabIndex = rndIndex;
        return rndIndex;
    }
}
