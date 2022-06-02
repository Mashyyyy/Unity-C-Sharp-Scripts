using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnectToMain : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        //Connects using settings based on the PhotonServerSettings asset
        PhotonNetwork.ConnectUsingSettings();
    }

    //Listens when the end-user is connected to a master server
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server");
        PhotonNetwork.LoadLevel("Lobby");
        base.OnConnectedToMaster();
    }

    //Listens when the end-user is disconnected to a server / lobby
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogError("Disconnected to Server/Lobby: " + cause);
        base.OnDisconnected(cause);
    }
}