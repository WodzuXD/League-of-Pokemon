using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMotor : MonoBehaviour
{
    NavMeshAgent agent;

    //setup
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    //moving
    public void moveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
}
