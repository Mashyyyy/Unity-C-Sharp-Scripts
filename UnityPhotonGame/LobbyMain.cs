using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyMain : MonoBehaviourPunCallbacks
{
    public GameObject JoinRoomCanvas, CreateRoomCanvas, MasterCanvas, LobbyConnectingCanvas, LobbyNameCanvas;
    public InputField roomIdToJoin;

    private string roomName;

    private void Awake()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        LobbyConnectingCanvas.SetActive(false);
        if(PhotonNetwork.NickName == null)
            LobbyNameCanvas.SetActive(true);
        Debug.Log("Connected to Lobby");
    }

    public void OnClick_CreateRoom()
    {
        int roomId = Random.Range(100000, 999999);
        roomName = roomId.ToString();

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 2;
        
        PhotonNetwork.CreateRoom(roomName, roomOptions, TypedLobby.Default);
    }
    public void OnClick_JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomIdToJoin.text);
    }
    //Button for Singleplayer AI
    public void OnClick_SPAI()
    {
        SceneManager.LoadScene("Scene1AI");
    }

    public void LevelToLoad(string levelToLoad)
    {
        PlayerPrefs.SetString("LevelToLoad", levelToLoad);
        PlayerPrefs.Save();
    }


    public override void OnCreatedRoom()
    {
        //PhotonNetwork.LoadLevel("Room");

        Debug.Log("Room Created with name: " + roomName);
        MasterCanvas.SetActive(false);
        CreateRoomCanvas.SetActive(true);
        PhotonNetwork.LoadLevel("Room");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Room Creation Failed:/" + message);
        base.OnCreateRoomFailed(returnCode, message);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Room");
        MasterCanvas.SetActive(false);
        JoinRoomCanvas.SetActive(true);
        base.OnJoinedRoom();
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Failed to Join Room. \nReason(s): " + message);
        base.OnJoinRoomFailed(returnCode, message);
    }

    //If you get f******g disconnected
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogError("Disconnected to Lobby \n Reason(s): " + cause);
        base.OnDisconnected(cause);
    }
}