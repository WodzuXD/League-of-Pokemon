using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject target;
    private float Cooldown = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        Cooldown -= Time.deltaTime;

        if (Cooldown < 0 && target != null)
        {
            target.GetComponent<Character>().Damage(2f);
            Debug.Log("HIT");
            Cooldown = 2f;
        }
    }

    //Enrering to collision sphere
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("wchodzi");
        if (collision.transform.tag == "Player" && target == null)
        {
            target = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == target)
            target = null;
    }
}
