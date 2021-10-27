using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class jogadorController : MonoBehaviourPunCallbacks
{
    private Player _photonPlayer;
    private int _id;


    [PunRPC]
    private void Inicializar(Player player)
    {
        _photonPlayer = player;
        _id = player.ActorNumber;
        GameController.Instancia.Jogadores.Add(this);
    }
}
