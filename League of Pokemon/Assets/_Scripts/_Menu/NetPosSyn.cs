using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetPosSyn : Photon.MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo pmi)
    {
        if (photonView.isMine)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            transform.position = (Vector3) stream.ReceiveNext();
            transform.rotation = (Quaternion) stream.ReceiveNext();
        }
    }

}
