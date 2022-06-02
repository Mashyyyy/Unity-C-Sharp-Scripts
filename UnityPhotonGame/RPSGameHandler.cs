using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;




public class RPSGameHandler : MonoBehaviourPunCallbacks
{
    [Header("Text Values")]
    public Text player1Name;
    public Text player2Name;

    public GameObject playerPrefab;
    private GameObject GO;

    [SerializeField]
    private RPSGameManager _rps;

    private void Awake()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, playerPrefab.transform.position, Quaternion.identity);
    }



    private void Start()
    {
        OnRoomJoinedOrCreated(PhotonNetwork.LocalPlayer);
        OnLoad();
    }

    void OnRoomJoinedOrCreated(Player currentPlayer)
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            player1Name.text = currentPlayer.NickName;
            player2Name.text = PhotonNetwork.MasterClient.NickName;
            GetComponent<PhotonView>().RPC("SetNicknameForMasterClient", RpcTarget.AllBuffered, currentPlayer.NickName);
        }
        else
        {
            player1Name.text = currentPlayer.NickName;
        }
    }

    [PunRPC]
    void SetNicknameForMasterClient(string name)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            player2Name.text = name;
        }
    }

    void OnLoad()
    {
        _rps.enabled = true;
    }
}