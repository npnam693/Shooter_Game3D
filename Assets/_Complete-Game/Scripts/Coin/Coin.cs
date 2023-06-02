using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviourPunCallbacks, IPunObservable
{

    [SerializeField] float rotateSpeed = 180;
    public bool isHide = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed *  Time.deltaTime);
        if (isHide)
        {
            Destroy(this.gameObject, 0f);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(isHide);
        }
        else
        {
            if ((bool) stream.ReceiveNext()) 
                isHide = true;
        }
    }
}
