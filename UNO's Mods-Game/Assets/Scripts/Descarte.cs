using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Descarte : MonoBehaviourPunCallbacks
{

    private Animator anim;
   // [SerializeField] private GameObject descarte;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    

    void Update()
    {
        if (GameController.Instancia.ObterMomento())
        {
           photonView.RPC("MudarCarta", RpcTarget.AllBuffered, GameController.Instancia.Obtercarta());
            GameController.Instancia.mudar = false;
 
        }

    }

    [PunRPC]
    public void MudarCarta(string carta)
    {
        anim.SetTrigger("Initial");
        anim.SetTrigger(carta);
    }


}
