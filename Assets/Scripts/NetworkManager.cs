using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    //// The App ID of your Photon application
    //[SerializeField] private string appId;
    [SerializeField] Transform player1SpawnPos, player2SpawnPos;

    void Start()
    {
        // Connect to Photon with the App ID
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon master server!");

        // Join a random room
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a room, creating a new one.");

        // Create a new room
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 4 });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room with " + PhotonNetwork.CurrentRoom.PlayerCount + " players.");

        // Spawn the player object
        PhotonNetwork.Instantiate("Player1", player1SpawnPos.position, Quaternion.identity);
        PhotonNetwork.Instantiate("Player2", player2SpawnPos.position, Quaternion.identity);
    }
}
