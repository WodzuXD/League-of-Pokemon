using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSC : MonoBehaviour
{
    public int icon;
    public Sprite[] icons;
    public Image iconButton;

    public GameObject iconsPanel;
    public InputField nickField;
    public Slider sl;

    public ConnectionsMannager cm;
    public Player pl;

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
            SceneManager.LoadScene(1);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        iconButton.sprite = icons[icon];

        if (sl.value < 0.3f)
            sl.value = 0f;
        if (sl.value > 0.7f)
            sl.value = 1f;
        if (sl.value <= 0.7f && sl.value >= 0.3f)
            sl.value = 0.5f;
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
