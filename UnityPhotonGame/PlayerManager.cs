using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using System.IO;
using Photon.Pun;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    private PhotonView pv;
    public GameObject myAvatar;

    public List<GameObject> playerAvatars;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        if (pv.IsMine)
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                myAvatar = PhotonNetwork.Instantiate(playerAvatars[1].name, playerAvatars[1].transform.position, playerAvatars[1].transform.rotation, 0);
            }
            else
            {
                myAvatar = PhotonNetwork.Instantiate(playerAvatars[0].name, playerAvatars[0].transform.position, playerAvatars[0].transform.rotation, 0);
            }
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            Debug.Log("We Are spawning as Player 1");
            GameObject.FindGameObjectWithTag("Player2Camera").SetActive(false);
        }
        else
        {
            Debug.Log("We Are spawning as Player 2");
            GameObject.FindGameObjectWithTag("Player1Camera").SetActive(false);
        }
    }
}