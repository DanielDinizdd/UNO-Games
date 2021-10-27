using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonHelp : MonoBehaviour
{
 
    public GameObject tela0;
    bool click = false, button = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (click)
        {
            button = !button;
            tela0.SetActive(button);
            ClickValor();
        }
    }

    public void ClickValor()
    {
        click = !click;
    }

   
}
