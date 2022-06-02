using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class SpawnUnits2 : MonoBehaviourPunCallbacks
{
    public List<GameObject> units;
    public Transform spawnPoint;
    public List<Button> spawnButtons;

    private void Awake()
    {
        
    }

    public void OnSpawn_Unit1()
    {
        if (photonView.IsMine)
        {
            spawnButtons[0].interactable = false;
            PhotonNetwork.Instantiate(units[0].name, spawnPoint.position, Quaternion.identity);
        }
    }

    public void OnSpawn_Unit2()
    {
        if (photonView.IsMine)
        {
            spawnButtons[1].interactable = false;
            PhotonNetwork.Instantiate(units[1].name, spawnPoint.position, Quaternion.identity);
        }
    }

    public void OnSpawn_Unit3()
    {
        if (photonView.IsMine)
        {
            spawnButtons[2].interactable = false;
            PhotonNetwork.Instantiate(units[2].name, spawnPoint.position, Quaternion.identity);
        }
    }
}