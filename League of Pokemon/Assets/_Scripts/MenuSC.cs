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
            cm.ConnectToGameServer();
        }
    }
    
    void Update()
    {
        if (sl.value > 0.35f && sl.value < 0.65f)
            sl.value = 0.5f;
        if (sl.value < 0.35f)
            sl.value = 0.0f;
        if (sl.value > 0.65f)
            sl.value = 1.0f;
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
