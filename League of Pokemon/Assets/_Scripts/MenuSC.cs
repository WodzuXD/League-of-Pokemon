using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSC : MonoBehaviour
{
    public int icon;
    public Sprite[] icons;
    public Image iconButton;

    public GameObject iconsPanel;
    public InputField nickField;
    public Slider sl;

    public ConnectionsMannager cm;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ConnectPlay()
    {
        if (nickField.text.Length > 3)
        {
            PhotonNetwork.playerName = nickField.text;
            cm.ConnectToGameServer();
        }
    }
    
    void Update()
    {
        iconButton.sprite = icons[icon];
    }

    public void IconsPanelButton()
    {
        iconsPanel.active = true;
    }

    public void ChangeIcone(int id)
    {
        icon = id;
        iconsPanel.active = false;
    }
}
