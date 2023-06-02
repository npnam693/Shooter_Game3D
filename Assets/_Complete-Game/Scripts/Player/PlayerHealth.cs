using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Photon.Pun;

namespace CompleteProject
{
    public class PlayerHealth : MonoBehaviourPunCallbacks
    {
        public static PlayerHealth Instance { get; private set; }
        public int startingHealth = 100;                            // The amount of health the player starts the game with.
        public int currentHealth;                                   // The current health the player has.
        public Slider healthSlider;                                 // Reference to the UI's health bar.
        public AudioClip deathClip;                                 // The audio clip to play when the player dies.
        public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
        public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.


        Animator anim;                                              // Reference to the Animator component.
        AudioSource playerAudio;                                    // Reference to the AudioSource component.
        PlayerMovement playerMovement;                              // Reference to the player's movement.
        PlayerShooting playerShooting;                              // Reference to the PlayerShooting script.
        bool isDead;
        PhotonView view;

        private void Start()
        {
            view = GetComponent<PhotonView>();
            if (view.IsMine)
            {
                // This is the local player's instance, so set the Instance property.
                Instance = this;
            }
        }
        void Awake ()
        {

            //if (Instance != null && Instance != this)
            //{
            //    Destroy(gameObject);
            //    return;
            //}
            Instance = this;
            DontDestroyOnLoad(gameObject);
            // Setting up the references.
            anim = GetComponent <Animator> ();
            playerAudio = GetComponent <AudioSource> ();
            playerMovement = GetComponent <PlayerMovement> ();
            playerShooting = GetComponentInChildren <PlayerShooting> ();
            // Set the initial health of the player.
            currentHealth = startingHealth;
        }    
        public void TakeDamage (int amount)
        {
            // Reduce the current health by the damage amount.
            currentHealth -= amount;

            // Set the health bar's value to the current health.
            healthSlider.value = currentHealth;

            // Play the hurt sound effect.
            playerAudio.Play ();

            // If the player has lost all it's health and the death flag hasn't been set yet...
            if(currentHealth <= 0 && !isDead)
            {
                // ... it should die.
                Death ();
            }
            view.RPC("UpdateCurrentHealth", RpcTarget.Others, currentHealth);
        }

        [PunRPC]
        void UpdateCurrentHealth(int health)
        {
            currentHealth = health;
            healthSlider.value = currentHealth;
        }


        void Death ()
        {
            // Set the death flag so this function won't be called again.
            isDead = true;

            // Turn off any remaining shooting effects.
            playerShooting.DisableEffects ();

            // Tell the animator that the player is dead.
            anim.SetTrigger ("Die");

            // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
            playerAudio.clip = deathClip;
            playerAudio.Play ();

            // Turn off the movement and shooting scripts.
            playerMovement.enabled = false;
            playerShooting.enabled = false;
        }


        public void RestartLevel ()
        {
            // Reload the level that is currently loaded.
            //SceneManager.LoadScene ("GameScene");
        }
        public int GetCurrentHealth()
        {
            return currentHealth;
        }
        
    }
}