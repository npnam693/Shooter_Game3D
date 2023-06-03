using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        GameObject player0;               // Reference to the player's position.
        GameObject player1;               // Reference to the player's position.
        PlayerHealth playerHealth0;      // Reference to the player's health.
        PlayerHealth playerHealth1;      // Reference to the player's health.
        EnemyHealth enemyHealth;        // Reference to this enemy's health.
        UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
        Animator anim;                              // Reference to the animator.
         
        void Start()
        {
            // Set up the references.
            GameObject[] player = GameObject.FindGameObjectsWithTag("Player");

            player0 = player[0];
            player1 = player[1];
            
            playerHealth0 = player0.GetComponentInParent <PlayerHealth> ();
            playerHealth0 = player1.GetComponentInParent<PlayerHealth> ();

            enemyHealth = GetComponent <EnemyHealth> ();
            nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
            anim = GetComponent<Animator>();
        }

        void Update ()
        {
            // If the enemy and the player have health left...


            if (enemyHealth.currentHealth > 0 && nav.enabled)
            {
                // ... set the destination of the nav mesh agent to the player.
                float dEnm_player0 = (player0.transform.position.x - this.transform.position.x) * (player0.transform.position.x - this.transform.position.x) +
                                    (player0.transform.position.z - this.transform.position.z) * (player0.transform.position.z - this.transform.position.z);

                float dEnm_player1= (player1.transform.position.x - this.transform.position.x) * (player1.transform.position.x - this.transform.position.x) +
                    (player1.transform.position.z - this.transform.position.z) * (player1.transform.position.z - this.transform.position.z);

                if (dEnm_player0 > dEnm_player1 && dEnm_player1 < 500)
                {
                    nav.SetDestination (player1.transform.position);
                    anim.SetBool("IsWalking", true);
                }
                else if (dEnm_player1 > dEnm_player0 && dEnm_player0 < 500)
                {
                    nav.SetDestination(player0.transform.position);
                    anim.SetBool("IsWalking", true);
                }     
                else
                {
                    anim.SetBool("IsWalking", false);
                }
            }
            // Otherwise...
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }
        }
    }
}