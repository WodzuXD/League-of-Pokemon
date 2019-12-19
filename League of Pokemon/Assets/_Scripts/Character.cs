using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(NavMeshAgent))]
public class Character : MonoBehaviour
{
    public string pokemonName;

    CharacterController CharacterController;
    NavMeshAgent agent;

    [SerializeField]
    float HP;
    [SerializeField]
    float HPMax;
    [SerializeField]
    float speed;
    [SerializeField]
    int damage;
    [SerializeField]
    int lifeSteal;
    [SerializeField]
    float attackSpeed;

    [SerializeField]
    TextMeshProUGUI nameBox;
    [SerializeField]
    Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        nameBox.text = pokemonName;
        healthSlider.value = HP / HPMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
