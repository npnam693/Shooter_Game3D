using UnityEngine;

namespace CompleteProject
{
    public class GameOverManager : MonoBehaviour
    {
        PlayerHealth playerHealth1;       // Reference to the player's health.
        PlayerHealth playerHealth2;       // Reference to the player's health.
        
        Animator anim;                          // Reference to the animator component.
        int numUserWin;

        void Awake ()
        {
            // Set up the reference.
            anim = GetComponent <Animator> ();
        }
        public int getNumUserWin()
        {
            return numUserWin;
        }
        void Update ()
        {
            // If the player has run out of health...
            GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
            if (player.Length == 2) { 
                playerHealth1 = player[0].GetComponentInParent<PlayerHealth>();
                playerHealth2 = player[1].GetComponentInParent<PlayerHealth>();

                if (playerHealth1.currentHealth <= 0 || playerHealth2.currentHealth < 2)
                {
                    // ... tell the animator the game is over.
                    anim.SetTrigger("GameOver");
                }

                int countWin = 0;

                if (player[0].transform.position.z < -40 && player[0].transform.position.z > -49 
                    && player[0].transform.position.x >-15.5 && player[0].transform.position.x < -7)
                    countWin++;
                if (player[1].transform.position.z < -40 && player[1].transform.position.z > -49
                    && player[1].transform.position.x > -15.5 && player[1].transform.position.x < -7)
                    countWin++;
                numUserWin = countWin;

                if (numUserWin == 2)
                {
                    // Setup show win 
                }
            }
        }
    }
}