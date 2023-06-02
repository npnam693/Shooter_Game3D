using Photon.Pun;
using UnityEngine;
namespace CompleteProject
{
    public class CoinManager : MonoBehaviourPunCallbacks
    {
        public float spawnTime = 1f;            // How long between each spawn.
        public string prefabName;                // The enemy prefab to be spawned.

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }

        void Spawn()
        {
            // If the player has no health left...
            //if (playerHealth.currentHealth <= 0f)
            //{
            //    // ... exit the function.
            //    return;
            //}

            if (PhotonNetwork.InRoom && PhotonNetwork.PlayerList.Length > 1)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    // Find a random index between zero and one less than the number of spawn points.
                    Vector3 spawPoint = new Vector3(Random.Range(-176,0), 1, Random.Range(-22, -62));

                    // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
                    PhotonNetwork.Instantiate(prefabName, spawPoint, new Quaternion(0, 0, 0, 0));
                }
            }
        }
    }
}
