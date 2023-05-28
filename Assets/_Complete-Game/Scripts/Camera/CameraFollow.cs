using UnityEngine;
using System.Collections;
using Photon.Pun;


namespace CompleteProject
{
    public class CameraFollow : MonoBehaviourPunCallbacks
    {
        public Transform player;
        public GameObject playerCamera;


        public float smoothing = 5f;        // The s    peed with which the camera will be following.
        Vector3 offset;                     // The initial offset from the target.

        void Start ()
        {
            if (photonView.IsMine)
            {
                playerCamera.SetActive(true);
                offset = playerCamera.transform.position - player.position;
            }    
        }



        void FixedUpdate ()
        {
            if (!photonView.IsMine) return;   
            // Create a postion the camera is aiming for based on the offset from the target.
            Vector3 targetCamPos = player.position + offset;

            // Smoothly interpolate between the camera's current position and it's target position.
            playerCamera.transform.position = Vector3.Lerp (playerCamera.transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}