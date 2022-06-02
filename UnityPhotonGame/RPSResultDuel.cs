using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class RPSResultDuel : MonoBehaviourPunCallbacks
{
    [Header("Score Values")]
    public Text p1Score;
    public Text p2Score;
    private int _p1Score;
    private int _p2Score;


    [Header("Image Choices")]
    public Image p1ChoiceImg;
    public Image p2ChoiceImg;

    [Header("Images")]
    /*
     *  0 - Rock / 1 - Paper / 2 - Scissor
     */
    public List<Sprite> choices;

    [Header("Text Result")]
    public Text p1Result;
    public Text p2Result;

    public void result(string p1Choice, string p2Choice)
    {
        switch (p1Choice)
        {
            case "Rock":
                {
                    if (!PhotonNetwork.IsMasterClient)
                    {
                        switch (p2Choice)
                        {
                            case "Rock":
                                {
                                    //DRAW (Player 2 Side)
                                    p1ChoiceImg.sprite = choices[0];
                                    p2ChoiceImg.sprite = choices[0];
                                    p1Result.text = "DRAW";
                                    p2Result.text = "DRAW";
                                    break;
                                }
                            case "Paper":
                                {
                                    //WIN (Player 2 Side)
                                    p1ChoiceImg.sprite = choices[1];
                                    p2ChoiceImg.sprite = choices[0];
                                    p1Result.text = "WIN";
                                    p2Result.text = "LOSE";
                                    GetComponent<PhotonView>().RPC("AddPlayer2Score", RpcTarget.AllBuffered);
                                    break;
                                }
                            case "Scissor":
                                {
                                    //LOSE (Player 2 Side)
                                    p1ChoiceImg.sprite = choices[2];
                                    p2ChoiceImg.sprite = choices[0];
                                    p1Result.text = "LOSE";
                                    p2Result.text = "WIN";
                                    GetComponent<PhotonView>().RPC("AddPlayer1Score", RpcTarget.AllBuffered);
                                    break;
                                }
                        }
                    }
                    else
                    {
                        switch (p2Choice)
                        {
                            case "Rock":
                                {
                                    //DRAW (Player 1 Side)
                                    p1ChoiceImg.sprite = choices[0];
                                    p2ChoiceImg.sprite = choices[0];
                                    p1Result.text = "DRAW";
                                    p2Result.text = "DRAW";
                                    break;
                                }
                            case "Paper":
                                {
                                    //LOSE (Player 1 Side)
                                    p1ChoiceImg.sprite = choices[0];
                                    p2ChoiceImg.sprite = choices[1];
                                    p1Result.text = "LOSE";
                                    p2Result.text = "WIN";
                                    GetComponent<PhotonView>().RPC("AddPlayer2Score", RpcTarget.AllBuffered);
                                    break;
                                }
                            case "Scissor":
                                {
                                    //WIN (Player 1 Side)
                                    p1ChoiceImg.sprite = choices[0];
                                    p2ChoiceImg.sprite = choices[2];
                                    p1Result.text = "WIN";
                                    p2Result.text = "LOSE";
                                    GetComponent<PhotonView>().RPC("AddPlayer1Score", RpcTarget.AllBuffered);
                                    break;
                                }
                        }
                    }
                    break;
                }
            case "Paper":
                {
                    Debug.Log("Entered Eval Phase Choice of P1, PAPER");
                    if (!PhotonNetwork.IsMasterClient)
                    {
                        switch (p2Choice)
                        {
                            case "Rock":
                                {
                                    //LOSE (Player 2 Side)
                                    p1ChoiceImg.sprite = choices[0];
                                    p2ChoiceImg.sprite = choices[1];
                                    p1Result.text = "LOSE";
                                    p2Result.text = "WIN";
                                    GetComponent<PhotonView>().RPC("AddPlayer1Score", RpcTarget.AllBuffered);
                                    break;
                                }
                            case "Paper":
                                {
                                    //DRAW (Player 2 Side)
                                    p1ChoiceImg.sprite = choices[1];
                                    p2ChoiceImg.sprite = choices[1];
                                    p1Result.text = "DRAW";
                                    p2Result.text = "DRAW";
                                    break;
                                }
                            case "Scissor":
                                {
                                    //WIN (Player 2 Side)
                                    p1ChoiceImg.sprite = choices[2];
                                    p2ChoiceImg.sprite = choices[1];
                                    p1Result.text = "WIN";
                                    p2Result.text = "LOSE";
                                    GetComponent<PhotonView>().RPC("AddPlayer2Score", RpcTarget.AllBuffered);
                                    break;
                                }
                        }
                    }
                    else
                    {
                        switch (p2Choice)
                        {
                            case "Rock":
                                {
                                    //WIN (Player 1 Side)
                                    p1ChoiceImg.sprite = choices[1];
                                    p2ChoiceImg.sprite = choices[0];
                                    p1Result.text = "WIN";
                                    p2Result.text = "LOSE";
                                    GetComponent<PhotonView>().RPC("AddPlayer1Score", RpcTarget.AllBuffered);
                                    break;
                                }
                            case "Paper":
                                {
                                    //DRAW (Player 1 Side)
                                    p1ChoiceImg.sprite = choices[1];
                                    p2ChoiceImg.sprite = choices[1];
                                    p1Result.text = "DRAW";
                                    p2Result.text = "DRAW";
                                    break;
                                }
                            case "Scissor":
                                {
                                    //LOSE (Player 1 Side)
                                    p1ChoiceImg.sprite = choices[1];
                                    p2ChoiceImg.sprite = choices[2];
                                    p1Result.text = "LOSE";
                                    p2Result.text = "WIN";
                                    GetComponent<PhotonView>().RPC("AddPlayer2Score", RpcTarget.AllBuffered);
                                    break;
                                }
                        }
                    }
                    break;
                }
            case "Scissor":
                {
                    Debug.Log("Entered Eval Phase Choice of P1, SCISSOR");
                    if (!PhotonNetwork.IsMasterClient)
                    {
                        switch (p2Choice)
                        {
                            case "Rock":
                                {
                                    //WIN (Player 2 Side)
                                    p1ChoiceImg.sprite = choices[0];
                                    p2ChoiceImg.sprite = choices[2];
                                    p1Result.text = "WIN";
                                    p2Result.text = "LOSE";
                                    GetComponent<PhotonView>().RPC("AddPlayer2Score", RpcTarget.AllBuffered);
                                    break;
                                }
                            case "Paper":
                                {
                                    //LOSE (Player 2 Side)
                                    p1ChoiceImg.sprite = choices[1];
                                    p2ChoiceImg.sprite = choices[2];
                                    p1Result.text = "LOSE";
                                    p2Result.text = "WIN";
                                    GetComponent<PhotonView>().RPC("AddPlayer1Score", RpcTarget.AllBuffered);
                                    break;
                                }
                            case "Scissor":
                                {
                                    //DRAW (Player 2 Side)
                                    p1ChoiceImg.sprite = choices[2];
                                    p2ChoiceImg.sprite = choices[2];
                                    p1Result.text = "DRAW";
                                    p2Result.text = "DRAW";
                                    break;
                                }
                        }
                    }
                    else
                    {
                        switch (p2Choice)
                        {
                            case "Rock":
                                {
                                    //LOSE (Player 1 Side)
                                    p1ChoiceImg.sprite = choices[2];
                                    p2ChoiceImg.sprite = choices[0];
                                    p1Result.text = "LOSE";
                                    p2Result.text = "WIN";
                                    GetComponent<PhotonView>().RPC("AddPlayer2Score", RpcTarget.AllBuffered);
                                    break;
                                }
                            case "Paper":
                                {
                                    //WIN (Player 1 Side)
                                    p1ChoiceImg.sprite = choices[2];
                                    p2ChoiceImg.sprite = choices[1];
                                    p1Result.text = "WIN";
                                    p2Result.text = "LOSE";
                                    GetComponent<PhotonView>().RPC("AddPlayer1Score", RpcTarget.AllBuffered);
                                    break;
                                }
                            case "Scissor":
                                {
                                    //DRAW (Player 1 Side)
                                    p1ChoiceImg.sprite = choices[2];
                                    p2ChoiceImg.sprite = choices[2];
                                    p1Result.text = "DRAW";
                                    p2Result.text = "DRAW";
                                    break;
                                }
                        }
                    }
                    break;
                }
        }
        GetComponent<Animator>().SetTrigger("DuelInitialize");
        Invoke("ResetAnim", 6f);
    }

    private void FixedUpdate()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            p1Score.text = _p2Score.ToString();
            p2Score.text = _p1Score.ToString();
        }
        else
        {
            p1Score.text = _p1Score.ToString();
            p2Score.text = _p2Score.ToString();
        }
    }

    [PunRPC]
    void AddPlayer1Score()
    {
        _p1Score++;
    }

    [PunRPC]
    void AddPlayer2Score()
    {
        _p2Score++;
    }


    void ResetAnim()
    {
        GetComponent<Animator>().SetTrigger("ResetDuel");
    }
}