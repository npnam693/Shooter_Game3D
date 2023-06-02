using UnityEngine;
using Photon.Pun;

namespace CompleteProject
{
    public class GameOverManager : MonoBehaviour
    {
        //public PlayerHealth playerHealth;       // Reference to the player's health.


        Animator anim;                          // Reference to the animator component.
        PhotonView view;

        void Awake ()
        {
            // Set up the reference.
            anim = GetComponent <Animator> ();
            view = GetComponent<PhotonView>();
        }


        [PunRPC]
        void SetGameOverTrigger()
        {
            anim.SetTrigger("GameOver");
        }

        void Update()
        {
            if (PlayerHealth.Instance.GetCurrentHealth() <= 0)
            {
                // Call the SetGameOverTrigger method on all clients.
                view.RPC("SetGameOverTrigger", RpcTarget.All);
            }
        }
    }
}