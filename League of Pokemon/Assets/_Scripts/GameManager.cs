using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SpawnPlayer ()
    {
        Vector3 spawnPosition = Vector3.zero;
        Transform spawns = GameObject.Find("Map_" + SceneManager.GetActiveScene().name + "/Spawns/" + Player.mainPlayer.team.ToString()).transform;
        spawnPosition = spawns.GetChild(Random.Range(0, spawns.childCount)).position;
        GameObject mainPlayerGO = PhotonNetwork.Instantiate("Player" + Player.mainPlayer.haracter, spawnPosition, Quaternion.identity, 0);
        mainPlayerGO.GetComponent<CharacterController>().enabled = true;
        mainPlayerGO.GetComponent<CharacterMotor>().enabled = true;
        GetComponent<PhotonView>().RPC("SpawnPlayerRPC", PhotonTargets.AllBuffered, Player.mainPlayer.nick, mainPlayerGO.GetComponent<PhotonView>().viewID, Player.mainPlayer.haracter);
    }

    [PunRPC]
    void SpawnPlayerRPC(string nick, int pvID, int character, PhotonMessageInfo pmi)
    {
        GameObject newPlayerGO = PhotonView.Find(pvID).gameObject;
        newPlayerGO.name = "Player_" + nick + "_" + character;
        Player player = Player.FindPlayer(pmi.sender);
        player.gameobject = newPlayerGO;
    }
}
