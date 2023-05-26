using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        Transform player;               // Reference to the player's position.
        PlayerHealth playerHealth;      // Reference to the player's health.
        EnemyHealth enemyHealth;        // Reference to this enemy's health.
        UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
        Animator anim;                              // Reference to the animator.

        void Awake ()
        {
            // Set up the references.
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent <EnemyHealth> ();
            nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
            anim = GetComponent<Animator>();
        }

        void Update ()
        {
            // If the enemy and the player have health left...
            if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                // ... set the destination of the nav mesh agent to the player.
                float dEnm_player = (player.position.x - this.transform.position.x) * (player.position.x - this.transform.position.x) +
                                    (player.position.y - this.transform.position.y) * (player.position.y - this.transform.position.y);

                if (dEnm_player < 40)
                {
                    nav.SetDestination (player.position);
                    anim.SetBool("IsWalking", true);
                }


                else
                {
                    //nav.enabled = false;
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