using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mao : EventTrigger
{

    private Animator anim;
    private string carta;


    private void Start()
    {
        anim = GetComponent<Animator>();
        

        carta = CardsController.Instancia.Cava();
        anim.SetTrigger(carta);
    }

    public override void OnPointerClick(PointerEventData data)
    {
        Debug.LogWarning("teste carta");
        float xPos = transform.position.x;
        //Debug.Log(xPos);
        
        GameController.Instancia.JogarCarta(carta, xPos);
        Destroy(gameObject);
    }


}
