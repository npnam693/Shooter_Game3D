using UnityEngine;
using System.Collections;
using Photon.Pun;

namespace CompleteProject
{
    public class CameraFollow : MonoBehaviour
    {
        public Vector3 offset;
        PhotonView view;
        private void Start()
        {
            view = GetComponent<PhotonView>();
        }

        private void LateUpdate()
        {
            if (view.IsMine)
            {
                Camera.main.transform.position = transform.position - offset;
            }
        }
    }
}