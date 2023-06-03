using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideCoin : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerShooting playerShooting;
    PlayerMovement playerMovement;
    void Start()
    {
        playerShooting = GetComponentInChildren<PlayerShooting>();
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CoinSpeed")
        {
            //Destroy(other.gameObject, 0);
            Coin coin = other.gameObject.GetComponent<Coin>();
            coin.isHide = true;
            playerMovement.speed += 3;
            StartCoroutine(highSpeedTime());
        }
        else if (other.gameObject.tag == "CoinDame")
        {
            Coin coin = other.gameObject.GetComponent<Coin>();
            coin.isHide = true;
            playerShooting.damagePerShot += 5;
        }
        else return;
    }

    IEnumerator highSpeedTime()
    {
        yield return new WaitForSeconds(2f);
        playerMovement.speed -= 3;
    }
}
