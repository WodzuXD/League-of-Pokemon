using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class CharacterController : MonoBehaviour
{
    public LayerMask mask;
    public LayerMask blockingMask;

    public bool canGiveDamage = false;

    Camera cam;
    CharacterMotor motor;

    public GameObject target = null;
    public float distance;

    // getting main camera and player motor
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<CharacterMotor>();
    }

    void Update()
    {
        //Following Target
        if (target != null)
        {

            if (distance < Vector3.Distance(gameObject.transform.position, target.transform.position))
            {
                canGiveDamage = false;
                motor.moveToPoint(target.transform.position);
            }
            else if (distance >= Vector3.Distance(gameObject.transform.position, target.transform.position))
            {
                canGiveDamage = true;
                motor.StopAllCoroutines();
                Debug.Log("HIT!");
            }
        }
        else
        {
            canGiveDamage = false;
        }


        // getting move destination from right button
        if (Input.GetMouseButton(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, blockingMask))
            {
                    return;
            }

            //Finding target
            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                if (hit.transform.tag == "Player" && hit.transform.GetComponent<Teams>().characterT != gameObject.GetComponent<Teams>().characterT)
                {
                    target = hit.transform.gameObject;
                }
                else
                {
                    target = null;
                    motor.moveToPoint(hit.point);
                }
            }
        }
    }
}
