using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    bool followPlayer = false;

    public float speed = 20f;
    public float zoomSpeed = 20f;

    float topBarrier = 0.93f;
    float botBarrier = 0.03f;
    float leftBarrier = 0.93f;
    float rightBarrier = 0.03f;

    public float topMax;
    public float botMax;
    public float leftMax;
    public float rightMax;

    public float maxHeight = 40f;
    public float minHeight = 4f;

    public Camera cam;
    public GameObject pl;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            followPlayer = !followPlayer;
        if(followPlayer)
            cam.transform.position = new Vector3(pl.transform.position.x, cam.transform.position.y, pl.transform.position.z - 3f);

        if (pl == null)
            pl = FindObjectOfType<CharacterMotor>().gameObject;

        if (Input.mousePosition.y >= Screen.height * topBarrier && cam.transform.position.z <= topMax)
            cam.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        if (Input.mousePosition.y <= Screen.height * botBarrier && cam.transform.position.z >= botMax)
            cam.transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
        if (Input.mousePosition.x >= Screen.width * rightBarrier && cam.transform.position.x <= rightMax)
            cam.transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        if (Input.mousePosition.x <= Screen.width * leftBarrier && cam.transform.position.x >= leftMax)
            cam.transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);

        if (Input.GetKey(KeyCode.Space))
            cam.transform.position = new Vector3(pl.transform.position.x, cam.transform.position.y, pl.transform.position.z - 3f);

    }
}
