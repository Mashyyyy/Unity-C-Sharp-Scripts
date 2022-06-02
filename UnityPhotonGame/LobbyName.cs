using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LobbyName : MonoBehaviourPunCallbacks
{
    public GameObject LobbyNameCanvas, MasterCanvas;

    public InputField nameInputField;

    public Text nameText;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("userName"))
        {
            OnInitialized_Information();
            MasterCanvas.SetActive(true);
        }
        else
        {
            LobbyNameCanvas.SetActive(true);
        }
    }


    //Initializes necessary information
    private void OnInitialized_Information()
    {
        if (PlayerPrefs.HasKey("userName"))
            PhotonNetwork.NickName = PlayerPrefs.GetString("userName");
        else
        {
            Debug.LogError("Warning! user's name is empty and is trying to initialize a null reference");
            MasterCanvas.SetActive(false);
            LobbyNameCanvas.SetActive(true);
            return;
        }

        nameText.text = PhotonNetwork.NickName;
        LobbyNameCanvas.SetActive(false);
        MasterCanvas.SetActive(true);
    }

    
    public void OnClick_SetName()
    {
        PhotonNetwork.NickName = nameInputField.text;
        PlayerPrefs.SetString("userName", nameInputField.text);
        PlayerPrefs.Save();
        OnInitialized_Information();
    }
}