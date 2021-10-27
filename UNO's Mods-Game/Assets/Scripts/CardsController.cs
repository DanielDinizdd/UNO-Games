using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsController : MonoBehaviour
{

    string[] blue_cards;
    string[] red_cards;
    string[] yellow_cards;
    string[] green_cards;
    string[] special_cards;

    private int _quantMao = 7;
    private int _quantidadeCartas = 108;
    private GameObject[] _cartas;
    [SerializeField] private GameObject _cartasMao;
    private Vector2 posicaoCartas = new Vector2(-12, 0);
    private float _posicaoXSpawn = -5f, _posicaoYSpawn = -4.5f, _posicaoZSpawn;
    private bool mudar = false;

    public static CardsController Instancia { get; private set; }

    void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            gameObject.SetActive(false);
            return;
        }
        Instancia = this;

        ValoresCartas();

        _cartas = new GameObject[_quantidadeCartas];

    }

    private void Update()
    {
        _posicaoXSpawn = -5f;
        _posicaoZSpawn = 0f;

        if (GameController.Instancia.start && mudar)
        {
            for (int i = 0; i < _quantMao; i++)
            {
                _cartas[i].transform.position = new Vector3(_posicaoXSpawn, _posicaoYSpawn, _posicaoZSpawn);

                _posicaoXSpawn += 0.4f;
                _posicaoZSpawn--;

            }
            mudar = false;
        }
    }

    public string CavaInicial()
    {
        string card = null;

        do
        {

            int random = Random.Range(0, 19);
            int cor = Random.Range(0, 4);
            switch (cor)
            {
                case 0:
                    if (blue_cards[random] != null)
                    {
                        card = blue_cards[random];
                        
                        blue_cards[random] = null;
                    }
                    break;

                case 1:
                    if (red_cards[random] != null)
                    {
                        card = red_cards[random];

                        red_cards[random] = null;
                    }
                    break;

                case 2:
                    if (green_cards[random] != null)
                    {
                        card = green_cards[random];

                        green_cards[random] = null;
                    }
                    break;

                case 3:
                    if (yellow_cards[random] != null)
                    {
                        card = yellow_cards[random];

                        yellow_cards[random] = null;
                    }
                    break;
            }

        } while (card == null);

        return card;

    }

    public string Cava()
    {
        string card = null;

        do
        {

            int random = Random.Range(0, 25);
            int cor = Random.Range(0, 5);
            switch (cor)
            {
                case 0:
                    if (blue_cards[random] != null)
                    {
                        card = blue_cards[random];

                        blue_cards[random] = null;
                    }
                    break;

                case 1:
                    if (red_cards[random] != null)
                    {
                        card = red_cards[random];

                        red_cards[random] = null;
                    }
                    break;

                case 2:
                    if (green_cards[random] != null)
                    {
                        card = green_cards[random];

                        green_cards[random] = null;
                    }
                    break;

                case 3:
                    if (yellow_cards[random] != null)
                    {
                        card = yellow_cards[random];

                        yellow_cards[random] = null;
                    }
                    break;
                case 4:
                    if(random < 7  && special_cards[random] != null)
                    {
                        card = special_cards[random];

                        special_cards[random] = null;
                    }
                    break;
            }

        } while (card == null);

        return card;
    }

    public void InstanciarCartas()
    {
        
        for (int i = 0; i < (_quantMao); i++)
        {
          _cartas[i] = Instantiate(_cartasMao, posicaoCartas, Quaternion.identity);

        }
        mudar = true;
    }

    public void JogarCarta(float xPos)
    {
        float auxPos = 5 + xPos;
        auxPos = (auxPos/0.4f);
        int aux = (int)auxPos;

        if (aux < _quantMao)
        {
            for(int i = aux; i < _quantMao; i++)
            {
                _cartas[i] = _cartas[i+1];
                
            }
            _quantMao -= 1;
            mudar = true;
        }

    }

    public void CavarCarta()
    {
        _cartas[_quantMao] = Instantiate(_cartasMao, posicaoCartas, Quaternion.identity);
        _quantMao += 1;
        mudar = true;
    }

    public void CavarCartaIncial()
    {
        InstanciarCartas();
    }

    private void ValoresCartas()
    {
        //As Strings "x" representa a carta de bloqueio/skip e as Strings "o" representa a carta de inversão/reverse
        blue_cards = new string[25]{ "blue0", "blue1", "blue2", "blue3", "blue4", "blue5", "blue6", "blue7", "blue8","blue9",
            "blue1", "blue2", "blue3", "blue4", "blue5", "blue6", "blue7", "blue8", "blue9",
            "blue+2", "bluex", "blueo", "blue+2", "bluex", "blueo" };

        red_cards = new string[25]{ "red0", "red1", "red2", "red3", "red4", "red5", "red6", "red7", "red8", "red9",
            "red1", "red2", "red3", "red4", "red5", "red6", "red7", "red8", "red9",
            "red+2", "redx", "redo", "red+2", "redx", "redo" };

        yellow_cards = new string[25]{ "yellow0", "yellow1", "yellow2", "yellow3", "yellow4", "yellow5", "yellow6", "yellow7", "yellow8", "yellow9",
            "yellow1", "yellow2", "yellow3", "yellow4", "yellow5", "yellow6", "yellow7", "yellow8", "yellow9",
            "yellow+2", "yellowx", "yellowo", "yellow+2", "yellowx", "yellowo" };

        green_cards = new string[25]{ "green0", "green1", "green2", "green3", "green4", "green5", "green6", "green7", "green8", "green9",
            "green1", "green2", "green3", "green4", "green5", "green6", "green7", "green8", "green9",
            "green+2", "greenx", "greeno", "green+2", "greenx", "greeno" };

        //As Strings "c" representam a carta da troca de cor/wild
        special_cards = new string[8] { "+4", "+4", "+4", "+4", "c", "c", "c", "c" };
    }


    private void OnDestroy()
    {
        if (CardsController.Instancia == this)
        {
            CardsController.Instancia = null;
        }

    }

}
