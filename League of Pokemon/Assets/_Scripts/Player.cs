using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string nick = "";
    public PhotonPlayer pp;

    public static List<Player> players = new List<Player>();

    public static void DebugPlayersList()
    {
        Debug.Log("Players List      " + players.Count + " Players!");
        foreach (var player in players)
        {
            Debug.Log(player.nick);
        }
    }
}
