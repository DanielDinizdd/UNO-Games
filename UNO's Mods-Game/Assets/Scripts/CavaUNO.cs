using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;

public class CavaUNO : EventTrigger
{
    private bool initialclick = true;

    public override void OnPointerClick (PointerEventData data)
    {
        if (initialclick)
        {
            //começar o jogo
            initialclick = false;
            //Debug.LogWarning("teste click inicial");
            string carta = CardsController.Instancia.CavaInicial();
            GameController.Instancia.photonView.RPC("IniciarJogo", RpcTarget.All, carta); 

            return;
        }

        CardsController.Instancia.CavarCarta();       
    }
}
