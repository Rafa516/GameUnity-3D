using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserController : MonoBehaviour, IMatavel
{
    //variaveis de rotacao e movimentacao personagem


    private Vector3 direct;

    public InterfaceScript scriptControlaInterface;
    public AudioClip DamageSound;
    public AudioClip RunningSound;
    public MovingPerson scriptMovingPerson;
    [HideInInspector]
    public Quaternion rotation;
    private AnimacaoPersonagem animacaoJogador;
    private int Kills;
    private ControlaArma controlaArma;

    public GameObject Frente;


    public Status statusJogador;



    void Start()
    {
        scriptMovingPerson = GetComponent<MovingPerson>();
        animacaoJogador = GetComponent<AnimacaoPersonagem>();
        statusJogador = GetComponent<Status>();
        scriptControlaInterface = GetComponent<InterfaceScript>();
        controlaArma = GameObject.FindObjectOfType<ControlaArma>() as ControlaArma;
        Kills = 0;
    }

    void Update()
    {
        
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");        //pegando entrada de direçoes pelo jogador no teclado ******aprimorar
        direct = new Vector3(eixoX, 0, eixoZ);

        animacaoJogador.Movimentar(direct.magnitude);   //animator
    }

    private void FixedUpdate()
    {
        scriptMovingPerson.Moving(direct,statusJogador.Velocidade);
    }

    public void TomarDano(int damage)
    {
        AudioController.instance.PlayOneShot(DamageSound);
        statusJogador.Vida -= damage;
        scriptControlaInterface.lifeaAndShieldRefresh();

        if(statusJogador.Vida <= 0)
        {
            Morrer();
        }


    }

    public void Morrer()
    {
        scriptControlaInterface.GameOver();
        gameObject.SetActive(false);
    }

    public void VoltarAtivo()
    {
        gameObject.SetActive(true);
    }
}

