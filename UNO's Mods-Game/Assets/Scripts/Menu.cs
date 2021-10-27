using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Menu : MonoBehaviourPunCallbacks
{
    [SerializeField] private MenuEntrada _menuEntrada;
    [SerializeField] private MenuLobby _menuLobby;

    private void Start()
    {
        _menuEntrada.gameObject.SetActive(false);
        _menuLobby.gameObject.SetActive(false);
        
    }

    public override void OnConnectedToMaster()
    {
        _menuEntrada.gameObject.SetActive(true);  
    }

    public override void OnJoinedRoom()
    {
        MudarMenu(_menuLobby.gameObject);
        _menuLobby.photonView.RPC("AtualizarLista" , RpcTarget.All);
    }

    public void MudarMenu(GameObject menu)
    {
        _menuEntrada.gameObject.SetActive(false);
        _menuLobby.gameObject.SetActive(false);

        menu.SetActive(true);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
    }

    public void SairLobby()
    {
        GestorDeRede.Instancia.SairLobby();
        MudarMenu(_menuEntrada.gameObject);
    }

    public void ComecarJogo()
    {
        GestorDeRede.Instancia.photonView.RPC("ComecarJogo", RpcTarget.All);
    }
}
