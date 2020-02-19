using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class CharacterController : MonoBehaviour
{
    public LayerMask mask;
    public LayerMask blockingMask;
    
    Camera cam;
    CharacterMotor motor;

    // getting main camera and player motor
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<CharacterMotor>();
    }

    void Update()
    {
        // getting move destination from right button
        if (Input.GetMouseButton(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, blockingMask))
            {
                return;
            }

            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                motor.moveToPoint(hit.point);
            }
        }
    }
}
