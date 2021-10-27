using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuEntrada : MonoBehaviour
{
    [SerializeField] private Text _playerName;
    [SerializeField] private Text _roomName;

    public void CriarSala()
    {
        GestorDeRede.Instancia.MudarNick(_playerName.text);
        GestorDeRede.Instancia.CriarSala(_roomName.text);
    }

    public void EntrarSala()
    {
        GestorDeRede.Instancia.MudarNick(_playerName.text);
        GestorDeRede.Instancia.EntrarSala(_roomName.text);
    }

}
