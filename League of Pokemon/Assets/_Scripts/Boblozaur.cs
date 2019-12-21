using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//pokemon skills, temponary HP calculations
public class Boblozaur : Character
{
    public LayerMask mask;
    public float[] skillCooldown;
    [SerializeField]
    float[] skillCooldownMax;
    [SerializeField]
    GameObject skillEAim;
    [SerializeField]
    public GameObject poisonCloudPrefab;
    //skills
    override protected void Update()
    {
        base.Update();

        skillCooldown[0] -= Time.deltaTime;
        skillCooldown[1] -= Time.deltaTime;
        skillCooldown[2] -= Time.deltaTime;
        skillCooldown[3] -= Time.deltaTime;
        Debug.Log("here");
        skillCooldown[0] = Mathf.Clamp(skillCooldown[0], 0, skillCooldownMax[0]);
        skillCooldown[1] = Mathf.Clamp(skillCooldown[1], 0, skillCooldownMax[1]);
        skillCooldown[2] = Mathf.Clamp(skillCooldown[2], 0, skillCooldownMax[2]);
        skillCooldown[3] = Mathf.Clamp(skillCooldown[3], 0, skillCooldownMax[3]);
        //Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (skillCooldown[0] < 0.01f)
            {
                //do stuff
            }
        }
        if (Input.GetKeyUp(KeyCode.Q) && !Input.GetMouseButton(0))
        {
            if (skillCooldown[0] < 0.01f)
            {
                //do stuff
                skillCooldown[0] = skillCooldownMax[0];
            }
        }
        //W
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (skillCooldown[1] < 0.01f)
            {
                //do
            }
        }
        if (Input.GetKeyUp(KeyCode.W) && !Input.GetMouseButton(0))
        {
            if (skillCooldown[1] < 0.01f)
            {
                //do stuff
                skillCooldown[1] = skillCooldownMax[1];
            }
        }
        //E
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (skillCooldown[2] < 0.01f)
            {
                skillEAim.SetActive(true);
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (skillCooldown[2] < 0.01f)
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100, mask))
                {
                    skillEAim.transform.position = hit.point;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.E) && !Input.GetMouseButton(0))
        {
            if (skillCooldown[2] < 0.01f)
            {
                Vector3 cloudPos = skillEAim.transform.position; //resping poison cloud
                cloudPos.y += 0.2f;
                Quaternion cloudRot = skillEAim.transform.rotation;
                GameObject cloud = Instantiate(poisonCloudPrefab, cloudPos, cloudRot);
                skillEAim.SetActive(false);
                skillCooldown[2] = skillCooldownMax[2];
            }
        }
        else
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                skillEAim.SetActive(false);
            }
        }
        //R
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (skillCooldown[3] < 0.01f)
            {
                HP += HPMax / 2f;
                HP = Mathf.Clamp(HP, 0, HPMax);
                skillCooldown[3] = skillCooldownMax[3];
            }
        }
    }
}
