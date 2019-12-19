using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionsMannager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ConnectToGameServer()
    {
        Debug.Log("Łączę");
        PhotonNetwork.ConnectUsingSettings("LoP_1.0");
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 20), PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }
}
