using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyAttack : MonoBehaviour
    {
        public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
        public int attackDamage = 10;               // The amount of health taken away per attack.


        Animator anim;                              // Reference to the animator component.
        GameObject player1;               // Reference to the player's position.
        GameObject player2;               // Reference to the player's position.
        PlayerHealth playerHealth1;      // Reference to the player's health.
        PlayerHealth playerHealth2;      // Reference to the player's health.
        EnemyHealth enemyHealth;                    // Reference to this enemy's health.
        int playerInRange;                         // Whether player is within the trigger collider and can be attacked.
        float timer;                                // Timer for counting up to the next attack.

        void Awake ()
        {
            // Setting up the references.
            GameObject[] player = GameObject.FindGameObjectsWithTag("Player");

            player1 = player[0];
            player2 = player[1];

            playerHealth1 = player1.GetComponentInParent<PlayerHealth>();
            playerHealth2 = player2.GetComponentInParent<PlayerHealth>();

            enemyHealth = GetComponent<EnemyHealth>();
            anim = GetComponent <Animator> ();
        }


        void OnTriggerEnter (Collider other)
        {
            // If the entering collider is the player...
            if(other.gameObject == player1)
            {
                // ... the player is in range.
                playerInRange = 1;
                Debug.Log("player1 collid");
            }

            if (other.gameObject == player2)
            {
                // ... the player is in range.
                playerInRange = 2;
                Debug.Log("player2 collid");
            }

        }


        void OnTriggerExit (Collider other)
        {
            // If the exiting collider is the player...
            if (other.gameObject == player1 || other.gameObject == player2)
            {
                // ... the player is no longer in range.
                playerInRange = 0;
            }
        }


        void Update ()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
            if(timer >= timeBetweenAttacks && playerInRange != 0 && enemyHealth.currentHealth > 0)
            {
                // ... attack.
                Attack ();
            }

            // If the player has zero or less health...
            //if (playerHealth.currentHealth <= 0)
            //{
            //    // ... tell the animator the player is dead.
            //    anim.SetTrigger("PlayerDead");
            //}
        }


        void Attack ()
        {
            // Reset the timer.
            timer = 0f;

            // If the player has health to lose...
            if(playerInRange == 1 && playerHealth1.currentHealth > 0)
            {
                // ... damage the player.
                playerHealth1.TakeDamage (attackDamage);
                Debug.Log("player1 dame");

            }
            if (playerInRange == 2 && playerHealth1.currentHealth > 0)
            {
                // ... damage the player.
                playerHealth2.TakeDamage(attackDamage);
                Debug.Log("player2 dame");
            }
        }
    }
}