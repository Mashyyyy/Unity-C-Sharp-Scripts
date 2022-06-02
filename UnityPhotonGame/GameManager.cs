using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject photonPlayer;
    private void Start()
    {
        PhotonNetwork.Instantiate(photonPlayer.name, this.gameObject.transform.position, Quaternion.identity);
    }
}