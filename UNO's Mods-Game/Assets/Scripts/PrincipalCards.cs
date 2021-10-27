using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalCards : MonoBehaviour
{
    bool click = false;
    string card;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ObterValor();
    }

    // Update is called once per frame
    void Update()
    {
        if (click && GameController.Instancia.start)
        {
            Virarcard();
            ClickValor();
        }
    }


    public void Virarcard()
    {
        anim.SetTrigger(card);
    }

    public void ObterValor()
    {
        card = CardsController.Instancia.CavaInicial();
    }

    public void ClickValor()
    {
        if (GameController.Instancia.start)
        {
            click = !click;
        }
        
    }
}
