using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager2 : MonoBehaviour
{
    public GameObject[] EnvPrefabs;
    public float zSpawn = 0;
    public float EnvLength = 30;
    public int numberOfEnv = 3;
    public Transform playerTransform;
    private List<GameObject> activeEnv = new List<GameObject>();

    void Start()
    {
        for(int i=0;i<numberOfEnv; i++)
        {
            if (i == 0)
            SpawnTile(0);
            else
            SpawnTile(Random.Range(0, EnvPrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z -35 > zSpawn - (numberOfEnv * EnvLength))
        {
            SpawnTile(Random.Range(0, EnvPrefabs.Length));
            DeleteEnv();
        }
    }
    public void SpawnTile(int EnvIndex)
    {
        GameObject go = Instantiate(EnvPrefabs[EnvIndex], transform.forward * zSpawn, transform.rotation);
        activeEnv.Add(go);
        zSpawn += EnvLength;

    }
    public void DeleteEnv()
    {
        Destroy(activeEnv[0]);
        activeEnv.RemoveAt(0);
    }
}

