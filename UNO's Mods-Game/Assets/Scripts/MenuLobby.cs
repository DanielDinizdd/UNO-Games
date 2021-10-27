using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MenuLobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text[] _listaDeJogadores;
    [SerializeField] private Text _nomeSala;
    [SerializeField] private Button _comecarJogo;


    [PunRPC]
    public void AtualizarLista()
    {
        int contador = 0;
        int aux = 0;
        string nickname = "";

        foreach (char letra in GestorDeRede.Instancia.ObterListaDeJogadores())
        {
            if (letra == '/')
            {
                _listaDeJogadores[contador].text = nickname.Substring(aux);
                aux += nickname.Length;
                contador++;
            }
            else
            {
                nickname += letra;
            }

            _comecarJogo.interactable = GestorDeRede.Instancia.MasterRoom();
        }
    }
}
