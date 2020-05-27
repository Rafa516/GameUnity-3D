using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{

    public int VidaInicial = 100;
    public int EscudoInicial = 0;
    [HideInInspector]
    public int Vida;
    [HideInInspector]
    public int Escudo;
    public float Velocidade = 8;
    public float VelocidadeInimigo = 6;
    public int Municao;
    public int Kills;

    private void Start()
    {
        Vida = VidaInicial;
        Escudo = EscudoInicial;
        Kills = 0;
    }
    private void Update()
    {
        Debug.Log(Municao);
    }

}
