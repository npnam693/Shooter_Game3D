using UnityEngine;
namespace CompleteProject
{
    public class CoinManager : MonoBehaviour
    {
        public float spawnTime = 1f;            // How long between each spawn.
        public GameObject coin;                // The enemy prefab to be spawned.

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

            // Find a random index between zero and one less than the number of spawn points.
            Vector3 spawPoint = new Vector3(Random.Range(-24, 24), 1, Random.Range(-24, 24));

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(coin, spawPoint, new Quaternion(0, 0, 0, 0));
        }
    }
}
