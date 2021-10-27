using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameController : MonoBehaviourPunCallbacks
{ 
    public bool start = false;
    public bool mudar = false;
    private string carta;
    private int contador = 0;
    [SerializeField] private string _localizacaoPrefab;
    [SerializeField] private Transform[] _posicaoJogadores;
    private int _numJogadores = 0;
    private List<jogadorController> _jogadores;
    public GameObject d;

    public static GameController Instancia{ get; private set; }
    public List<jogadorController> Jogadores { get => _jogadores; private set => _jogadores = value; }

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            gameObject.SetActive(false);
            return;
        }
        Instancia = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        photonView.RPC("AdicionarJogador", RpcTarget.AllBuffered);
        _jogadores = new List<jogadorController>();
    }

    [PunRPC]
    private void AdicionarJogador()
    {
        _numJogadores++;
        if (_numJogadores == PhotonNetwork.PlayerList.Length)
        {
            CriarJogador();
        }
    }

    private void CriarJogador()
    {
        var jogadorObj = PhotonNetwork.Instantiate(_localizacaoPrefab , _posicaoJogadores[Random.Range(0 , _posicaoJogadores.Length)].position , Quaternion.identity);
        var jogador = jogadorObj.GetComponent<jogadorController>();

        jogador.photonView.RPC("Inicializar", RpcTarget.All, PhotonNetwork.LocalPlayer);
        
    }

   
    [PunRPC]
    public void IniciarJogo(string carta)
    {
        start = true;
        d.SetActive(true);
        JogarCartaIniciaL(carta);
        CardsController.Instancia.CavarCartaIncial();
       // CardsController.Instancia.photonView.RPC("CavarCartaInicial", RpcTarget.AllBuffered);
    }

    private void OnDestroy()
    {
        if (GameController.Instancia == this)
        {
            GameController.Instancia = null;
        }

    }

    public void JogarCarta(string carta, float xPos)
    {
        mudar = true;
        this.carta = carta;
        CardsController.Instancia.JogarCarta(xPos);

    }

    public void JogarCartaIniciaL(string carta)
    {
        mudar = true;
        this.carta = carta;

    }

    public bool ObterMomento()
    {
        return mudar;
    }

    public string Obtercarta()
    {
        mudar = false;
        return carta;
    }



}
