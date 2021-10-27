using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextAndBack : MonoBehaviour
{

    public GameObject tela, nextTela, backTela;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        tela.SetActive(false);
        nextTela.SetActive(true);
    }

    public void Back()
    {
        tela.SetActive(false);
        backTela.SetActive(true);
    }
}
