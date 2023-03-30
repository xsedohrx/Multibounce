using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class BrickGenerator : MonoBehaviourPunCallbacks
{
    public GameObject[] brickPrefabs;
    public float xSpacing;
    public float ySpacing;
    public int rows;
    public int columns;

    private List<GameObject> bricks = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        CheckMasterClient();
    }

    private void CheckMasterClient()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GenerateBricks();
        }
    }

    void GenerateBricks()
    {
        // Calculate the starting position for the first brick
        float startX = -xSpacing * (columns - 1) / 2;
        float startY = ySpacing * (rows - 1) / 2;

        // Loop through each row and column to spawn the bricks
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Calculate the position for the current brick
                float xPos = startX + j * xSpacing;
                float yPos = startY - i * ySpacing;
                Vector3 position = new Vector3(xPos, yPos, 0f);

                // Randomly select a brick prefab to spawn
                GameObject brickPrefab = brickPrefabs[UnityEngine.Random.Range(0, brickPrefabs.Length)];

                // Spawn the brick and add it to the list of bricks
                GameObject brick = PhotonNetwork.Instantiate(brickPrefab.name, new Vector3(position.x,position.y,-1), Quaternion.identity);
                bricks.Add(brick);
            }
        }
    }

    public void ResetBricks()
    {
        // Destroy all the current bricks
        foreach (GameObject brick in bricks)
        {
            PhotonNetwork.Destroy(brick);
        }

        // Generate new bricks
        GenerateBricks();
    }
}