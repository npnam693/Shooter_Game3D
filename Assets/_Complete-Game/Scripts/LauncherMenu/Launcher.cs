using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Launcher : MonoBehaviourPunCallbacks
{
    public void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Connect();
        Debug.Log("run Function");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected!");
        Join();
        base.OnConnectedToMaster();
    }
    public void Connect()
    {
        Debug.Log("Connecting...");
        PhotonNetwork.GameVersion = "0.0.0";
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Join()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        StartGame();
        base.OnJoinedRoom();
    }

    public void StartGame()
    {
        Debug.Log("hello game");
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.LoadLevel(2);
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Create();
        base.OnJoinRandomFailed(returnCode, message);
    }

    public void Create()
    {
        PhotonNetwork.CreateRoom("");
    }
}
