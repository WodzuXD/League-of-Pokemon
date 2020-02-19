using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

//general character script for players minions and mobs
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(NavMeshAgent))]
public class Character : MonoBehaviour
{
    public string pokemonName;

    CharacterController CharacterController;
    NavMeshAgent agent;

    [SerializeField]
    protected float HP;
    [SerializeField]
    protected float HPMax;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected int lifeSteal;
    [SerializeField]
    protected float attackSpeed;

    [SerializeField]
    TextMeshProUGUI nameBox;
    [SerializeField]
    Slider healthSlider;

    protected Camera cam;
    
    // Setup
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        nameBox.text = pokemonName;
        healthSlider.value = HP / HPMax;
        cam = Camera.main;
    }

    // Update healtbar(only visual)
    protected virtual void Update()
    {
        healthSlider.value = HP / HPMax;
    }

    //Giving damage
    public void Damage(float hp)
    {
        HP -= hp;
    }
}
