using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorDeRede : MonoBehaviourPunCallbacks
{
    public static GestorDeRede Instancia { get; private set; }

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            gameObject.SetActive(false);
            return;
        }
        Instancia = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conexão bem sucedida");
    }

    public void CriarSala(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    public void EntrarSala(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void MudarNick(string nickname)
    {
        PhotonNetwork.NickName = nickname;
    }

    public string ObterListaDeJogadores()
    {
        var lista = "";

        foreach(var player in PhotonNetwork.PlayerList)
        {
            lista += player.NickName + "/";
        }

        return lista;
    }

    public bool MasterRoom()
    {
        return PhotonNetwork.IsMasterClient;
    }

    public void SairLobby()
    {
        PhotonNetwork.LeaveRoom();
    }

    [PunRPC]
    public void ComecarJogo()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
