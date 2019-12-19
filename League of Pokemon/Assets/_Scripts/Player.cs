using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string nick = "";
    public PhotonPlayer pp;

    public static List<Player> players = new List<Player>;
}
