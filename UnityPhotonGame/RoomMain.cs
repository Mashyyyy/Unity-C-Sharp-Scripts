using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomMain : MonoBehaviourPunCallbacks
{
    public Text RoomLobbyId;
    public Text Player1Name, Player2Name;

    public GameObject countdownHeader;
    public Text countdown;
    private int _countdownNo = 5;

    string name1;

    private void Awake()
    {
        RoomLobbyId.text = "Room ID: " + PhotonNetwork.CurrentRoom.Name;
    }

    private void Start()
    {
        OnRoomJoinedOrCreated(PhotonNetwork.LocalPlayer);
        //StartCoroutine(StartGame());
    }

    void OnRoomJoinedOrCreated(Player currentPlayer)
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Player1Name.text = currentPlayer.NickName;
            Player2Name.text = PhotonNetwork.MasterClient.NickName;
            StartCoroutine(StartGame());
        }
        else
        {
            Player1Name.text = currentPlayer.NickName;
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Player2Name.text = newPlayer.NickName;
            StartCoroutine(StartGame());
        }
    }
    IEnumerator StartGame()
    {
        countdownHeader.SetActive(true);

        while (_countdownNo > 0)
        {
            countdown.text = _countdownNo.ToString();

            yield return new WaitForSeconds(1f);

            _countdownNo--;
        }
        //Just Change manually for now
        PhotonNetwork.LoadLevel("Scene1RPS_PvP");
    }


    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Player2Name.text = "<waiting for other players>";
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogError("Disconnected to Lobby/Room \n Reason(s): " + cause);

        Debug.Log("Trying to Reconnect...");
        PhotonNetwork.ReconnectAndRejoin();
        base.OnDisconnected(cause);
    }
}