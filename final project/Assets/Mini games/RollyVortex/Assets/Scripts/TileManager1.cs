using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TileManager1 : MonoBehaviour
{
    public List<GameObject> activeTiles;
    public List<GameObject> tilePrefabs;


    public float tileLength = 12;
    public int nbrOfTiles = 3;

    public float zSpawn = 0;

    Transform player;

    int tileIndex;

    bool bb;
    
    List<Vector3> passedPositions;
    public List<Vector3> emptyPathPositions;
    int emptyPathsPassed = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        activeTiles = new List<GameObject>();

        passedPositions = new List<Vector3>();
        emptyPathPositions = new List<Vector3>();


        for (int i = 0; i < nbrOfTiles; i++)
        {
            SpawnTile();
        }

    }

    void LateUpdate()
    {
        if (player.position.z - 17 >= zSpawn - (nbrOfTiles * tileLength))
        {
            if (tileIndex < tilePrefabs.Count)
            {
                DeleteTile();
                SpawnTile();
            }
        }
    }

    
    public void SpawnTile()
    {
        if (tilePrefabs.Count == 0)
        {
            return;
        }

        GameObject tile = Instantiate(tilePrefabs[tileIndex % tilePrefabs.Count], Vector3.forward * zSpawn, Quaternion.identity);
            activeTiles.Add(tile);
            zSpawn += tileLength;
            tileIndex++;
        // Record the positions in the tile
        RecordPositionsInTile(tile);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private void RecordPositionsInTile(GameObject tile)
    {
        // Assuming the positions you want to track are children of the tile object
        Transform[] positions = tile.GetComponentsInChildren<Transform>();

        

        foreach (Transform position in positions)
        {
            // Ignore the tile's own transform component
            if (position != tile.transform)
            {

                // Check if the position is an empty path
                if (position.gameObject.CompareTag("EmptyPath"))
                {

                    emptyPathPositions.Add(position.position);
                    emptyPathsPassed++;
                }
                else
                {
                   passedPositions.Add(position.position);
                    
                }

            }
        }
    }

    public bool MarkEmptyPathPassed()
    {
       foreach (Vector3 position in emptyPathPositions)
        {
            if (!HasPassedPosition(position))
            {
                //return false;
                bb=false;
            }
            else
                bb=true;

        }

        return bb;
        //return true;
    }

    private bool CheckPassedPositions()
    {
        foreach (Vector3 position in passedPositions)
        {
            if (!HasPassedPosition(position))
            {
                return false;
            }
        }

        return true;
    }

    private bool HasPassedPosition(Vector3 position)
    {
        
        float distanceThreshold = 1f;
        return Vector3.Distance(player.position, position) < distanceThreshold;
    }


}

