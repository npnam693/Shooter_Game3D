using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviourPunCallbacks
{

    //public string Player_prefabs;
    //public GameObject player;
    public Transform SpawnPoint;

    private void Start()
    {
        Spawn();    
    }
    
    public void Spawn()
    {
        PhotonNetwork.Instantiate("Player", SpawnPoint.position, SpawnPoint.rotation);
    }
    
    void Update()
    {   
        
    }
}
