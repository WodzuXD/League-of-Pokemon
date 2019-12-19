using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMotor : MonoBehaviour
{
    NavMeshAgent agent;

    // getting agent
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // start move
    public void moveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
}
