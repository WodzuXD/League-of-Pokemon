using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectionsMannager : Photon.MonoBehaviour
{

    int haracter = 0;
    int team = 0;


    MenuSC msc;
    GameManager gm;

    private void Start()
    {
        msc = FindObjectOfType<MenuSC>();
        gm = GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            Player.DebugPlayersList();


    }

    public void ConnectToGameServer()
    {
        PhotonNetwork.sendRate = 20;
        PhotonNetwork.sendRateOnSerialize = 20;
        PhotonNetwork.ConnectUsingSettings("LoP_1.1");
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
            if (msc.sl.value == 0)
                team = 0;
            if (msc.sl.value == 1)
                team = 1;
            if (msc.sl.value == 0.5f)
                team = Random.Range(0, 2);
            haracter = msc.icon;
            photonView.RPC("PlayerConnected", PhotonTargets.AllBuffered, pp, team, haracter);
        }
    }

    void OnPhotonPlayerDisconnected(PhotonPlayer pp)
    {
        if (PhotonNetwork.isMasterClient)
        {
            photonView.RPC("PlayerDisconnected", PhotonTargets.AllBuffered, pp);
        }
    }

    [PunRPC]
    private void PlayerConnected(PhotonPlayer pp, int team, int character)
    {
        Player player = new Player();
        player.nick = pp.NickName;
        player.pp = pp;
        Player.players.Add(player);
        player.team = (Team)team;
        player.haracter = character;

        if (pp == PhotonNetwork.player)
        {
            //respienie gracza
            Player.mainPlayer = player;
            gm.SpawnPlayer();
        }
    }

    [PunRPC]
    private void PlayerDisconnected(PhotonPlayer pp)
    {
        var tmpPlayer = Player.FindPlayer(pp);
        if (tmpPlayer != null)
            Player.players.Remove(tmpPlayer);
    }

    void OnCreatedRoom()
    {
        if (msc.sl.value == 0)
            team = 0;
        if (msc.sl.value == 1)
            team = 1;
        if (msc.sl.value == 0.5f)
            team = Random.Range(0, 2);
        haracter = msc.icon;
        photonView.RPC("PlayerConnected", PhotonTargets.AllBuffered, PhotonNetwork.player, team, haracter);
    }
}
