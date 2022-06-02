using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RPSGameManager : MonoBehaviourPunCallbacks
{
    [Header("Timer")]
    public Text timer;
    private int _countdown = 15;

    [Header("Reset Timer")]
    public Text rTimer;
    private int _rCountdown = 5;

    [Header("Canvases")]
    public GameObject duelCanvas;
    public GameObject masterCanvas;

    public List<Sprite> localPChoice;
    //public List<Image> otherPChoice;

    [Header("Choice Display")]
    public Image Player1Choice;
    public Image Player2Choice;

    [Header("RPS Results")]
    public RPSResultDuel rpsResultsDuel;

    //Choices
    [SerializeField]
    private string p1Choice, p2Choice;

    private bool isP1Selected;
    private bool isP2Selected;

    //Turns true when both players already made their choice
    private bool forcedDuel = false;

    private bool commencedDuel = false;

    private void Start()
    {
        RPSGameLogic();
    }


    //Game Phase Logic
    private void RPSGameLogic()
    {
        StartCoroutine(duelTime());
    }

    IEnumerator duelTime()
    {

        while(_countdown > 0)
        {
            timer.text = _countdown.ToString();

            /*
            if (!forcedDuel)
            {
                _countdown = 5;
                forcedDuel = true;
            }
            */
            yield return new WaitForSeconds(1f);
            _countdown--;
        }

        commencedDuel = true;
        _countdown = 15;
        ResultTally();
        //duelCanvas.SetActive(true);
    }

    //Results Tally
    private void ResultTally()
    {
        rpsResultsDuel.result(p1Choice, p2Choice);
        StartCoroutine(resetPhase());
    }

    IEnumerator resetPhase()
    {
        yield return new WaitForSeconds(1f);
        rTimer.gameObject.SetActive(true);
        while (_rCountdown > 0)
        {
            rTimer.text = _rCountdown.ToString();

            /*
            if (!forcedDuel)
            {
                _countdown = 5;
                forcedDuel = true;
            }
            */
            yield return new WaitForSeconds(1f);
            _rCountdown--;
        }

        _rCountdown = 5;
        RPSGameLogic();
    }

    //Player 2 Turn
    public void GetPlayer2Choice(string choice)
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            //Choice of Player 2
            switch (choice)
            {
                case "Rock":
                    {
                        GetComponent<PhotonView>().RPC("Set2Choice", RpcTarget.AllBuffered, choice);
                        break;
                    }
                case "Paper":
                    {
                        GetComponent<PhotonView>().RPC("Set2Choice", RpcTarget.AllBuffered, choice);
                        break;
                    }
                case "Scissor":
                    {
                        GetComponent<PhotonView>().RPC("Set2Choice", RpcTarget.AllBuffered, choice);
                        break;
                    }
            }
            /*
            if (isP1Selected)
            {
                isP2Selected = true;
                forcedDuel = true;
            }
            else
            {
                isP2Selected = true;
            }
            */
        }
    }

    [PunRPC]
    void Set2Choice(string choice)
    {
        p2Choice = choice;
    }


    //Player 1 Turn
    public void GetPlayer1Choice(string choice)
    {
        //Choice of Player 1
        if (PhotonNetwork.IsMasterClient)
        {
            switch (choice)
            {
                case "Rock":
                    {
                        GetComponent<PhotonView>().RPC("Set1Choice", RpcTarget.AllBuffered, choice);
                        break;
                    }
                case "Paper":
                    {
                        GetComponent<PhotonView>().RPC("Set1Choice", RpcTarget.AllBuffered, choice);
                        break;
                    }
                case "Scissor":
                    {
                        GetComponent<PhotonView>().RPC("Set1Choice", RpcTarget.AllBuffered, choice);
                        break;
                    }
            }
            /*
            if (isP2Selected)
            {
                isP1Selected = true;
                forcedDuel = true;
            }
            else
            {
                isP1Selected = true;
            }
            */
        }
    }

    [PunRPC]
    void Set1Choice(string choice)
    {
        p1Choice = choice;
    }

    private void LateUpdate()
    {
        //Player 2 Updates
        if (!PhotonNetwork.IsMasterClient)
        {
            switch (p2Choice)
            {
                case "Rock":
                    {
                        Player1Choice.sprite = localPChoice[0];
                        break;
                    }
                case "Paper":
                    {
                        Player1Choice.sprite = localPChoice[1];
                        break;
                    }
                case "Scissor":
                    {
                        Player1Choice.sprite = localPChoice[2];
                        break;
                    }
            }
        }
        //Player 1 Updates
        else
        {
            switch (p1Choice)
            {
                case "Rock":
                    {
                        Player1Choice.sprite = localPChoice[0];
                        break;
                    }
                case "Paper":
                    {
                        Player1Choice.sprite = localPChoice[1];
                        break;
                    }
                case "Scissor":
                    {
                        Player1Choice.sprite = localPChoice[2];
                        break;
                    }
            }
        }
    }

    //Turn Wait
}