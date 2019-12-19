using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionsMannager : Photon.MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            Player.DebugPlayersList();
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

    void OnPhotonPlayerConnected(PhotonPlayer pp)
    {
        if (PhotonNetwork.isMasterClient)
        {
            photonView.RPC("PlayerConnected", PhotonTargets.AllBuffered, pp);
        }
    }

    void OnPhotonPlayerDisconnected(PhotonPlayer pp)
    {

    }

    [PunRPC]
    private void PlayerConnected(PhotonPlayer pp)
    {
        Player player = new Player();
        player.nick = pp.NickName;
        player.pp = pp;
        Player.players.Add(player);
    }

    [PunRPC]
    private void PlayerDisconnected(PhotonPlayer pp)
    {

    }

    void OnCreatedRoom()
    {
        photonView.RPC("PlayerConnected", PhotonTargets.AllBuffered, PhotonNetwork.player);
    }
}
