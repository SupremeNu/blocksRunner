using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {

    public GameObject[] tiles;
    public int numOfTilesOnScreen = 20;

    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private List<GameObject> activeTiles;
    private readonly int tileLength =58;
    private readonly int safeZone = 100;
    private int lastRandomtile = 0;

	public void Start ()
    {
        activeTiles = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;//gets the position of the player

        for(int i = 1; i <numOfTilesOnScreen; i++)//for all the starting tiles
        {
            Spawntile();//spawn them
        }
    }

    private void Update ()
    {
        if(playerTransform != null)//stops errors in console at the start
            if (playerTransform.position.z -safeZone> (spawnZ - numOfTilesOnScreen * tileLength))//when past the next tile
            {
                Spawntile();
                DeleteTile();
            }
	}

    private void Spawntile(int prefabIndex = -1)//for spawning tiles
    {
        GameObject newtile;
        newtile = Instantiate(tiles [Randomize()]) as GameObject;//creates a new tile and chooses a random one from the list tiles
        newtile.transform.position = Vector3.forward * spawnZ;//sets position
        spawnZ += tileLength;//every time a new tile is spawned the spawn point is added on so the next tile will spawn infront
        activeTiles.Add(newtile);//add the new tile to the stack
    }

    private void DeleteTile()//for deleting tiles
    {
        Destroy(activeTiles[0]);//destroys object in the game
        activeTiles.RemoveAt(0);//deletes item at the bottom of the stack
    }

    private int Randomize()//for choosing a random tile to spawn next
    {
        int newRandomTile = lastRandomtile;//overwrite the last random tile
        while (newRandomTile == lastRandomtile)//when overwritten (use while so not 2 of the same tiles in a row)
        {
            newRandomTile = Random.Range(0, tiles.Length);//choose a new random tile
        }
        lastRandomtile = newRandomTile;//set last to the new one
        return newRandomTile;
    }
}