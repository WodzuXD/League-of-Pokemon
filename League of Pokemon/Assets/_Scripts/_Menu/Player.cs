using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public GameObject gameobject;
    public static Player mainPlayer;
    public string nick = "";
    public PhotonPlayer pp;
    public Team team;
    public int haracter;

    public static List<Player> players = new List<Player>();

    public static void DebugPlayersList()
    {
        string dbgS = "Players List      " + players.Count + " Players!\n";
        int i = 0;
        foreach (var player in players)
            dbgS += "ID: " + i + ", Nick: " + player.nick + ", Character: " + player.haracter + ", Team: " + player.team + "\n";
            i++;
        Debug.Log(dbgS);
    }

    public static Player FindPlayer(PhotonPlayer pp)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].pp == pp)
                return players[i];
        }
        return null;
    }
}

public enum Team { tm1, tm2}