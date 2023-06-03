using UnityEngine;
using Photon.Pun;
namespace CompleteProject
{
    public class EnemyManager : MonoBehaviourPunCallbacks
    {
        //public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public string enemyPrefab_Name;                // The enemy prefab to be spawned.
        public float spawnTime = 3f;            // How long between each spawn.
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
        public int numSpawn;
        void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating ("Spawn", spawnTime, spawnTime);
        }


        void Spawn ()
        {
            // If the player has no health left...
            //if(playerHealth.currentHealth <= 0f)
            //{
            //    // ... exit the function.
            //    return;
            //}
            if (PhotonNetwork.InRoom && PhotonNetwork.PlayerList.Length > 1 && numSpawn > 0)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    numSpawn--;
                    // Find a random index between zero and one less than the number of spawn points.
                    int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                    // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
                    PhotonNetwork.Instantiate(enemyPrefab_Name, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                }
            }
        }
    }
}