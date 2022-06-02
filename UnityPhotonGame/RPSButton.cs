using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RPSButton : MonoBehaviourPunCallbacks
{
    private Animator anim;
    [SerializeField]
    private PhotonView pv;

    [SerializeField]
    private string p1Choice, p2Choice;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        pv = GetComponentInParent<PhotonView>();
    }


    private void Start()
    {
        if (pv.IsMine)
            this.transform.root.gameObject.SetActive(true);
        else
            this.transform.root.gameObject.SetActive(false);
    }



    //OnHover (when the user hovers their mouse over)
    public void OnHover_Buttons()
    {
        anim.SetBool("isActive", true);
    }



    //OffHover (when the user hovers off their mouse)
    public void OffHover_Buttons()
    {
        anim.SetBool("isActive", false);
    }


    //Choice [Rock]
    public void OnClick_ChoiceRock()
    {
        if (pv.IsMine)
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.Log("Choice: Rock");
                pv.RPC("GetPlayer2Choice", RpcTarget.AllBuffered, "Rock");
            }
            else
            {
                Debug.Log("Choice: Rock");
                pv.RPC("GetPlayer1Choice", RpcTarget.AllBuffered, "Rock");
            }
        }
    }

    //Choice [Paper]
    public void OnClick_ChoicePaper()
    {
        if (pv.IsMine)
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.Log("Choice: Paper");
                pv.RPC("GetPlayer2Choice", RpcTarget.AllBuffered, "Paper");
            }
            else
            {
                Debug.Log("Choice: Paper");
                pv.RPC("GetPlayer1Choice", RpcTarget.AllBuffered, "Paper");
            }
        }
    }

    //Choice [Scissor]
    public void OnClick_ChoiceScissor()
    {
        if (pv.IsMine)
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.Log("Choice: Scissor");
                pv.RPC("GetPlayer2Choice", RpcTarget.AllBuffered, "Scissor");
            }
            else
            {
                Debug.Log("Choice: Scissor");
                pv.RPC("GetPlayer1Choice", RpcTarget.AllBuffered, "Scissor");
            }
        }
    }

    [PunRPC]
    void GetPlayer1Choice(string choice)
    {
        GameObject.FindObjectOfType<RPSGameManager>().GetPlayer1Choice(choice);
        p1Choice = choice;
    }

    [PunRPC]
    void GetPlayer2Choice(string choice)
    {
        GameObject.FindObjectOfType<RPSGameManager>().GetPlayer2Choice(choice);
        p2Choice = choice;
    }
}