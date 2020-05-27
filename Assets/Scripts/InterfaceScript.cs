using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceScript : MonoBehaviour
{

    private UserController controlaUsuario;
    private ControlaArma controlaArma;
    public Slider SliderVidaJogador;
    public Text LifeText;
    public Text MunicaoText;
    public GameObject PainelDeGameOver;
    public Text TextoSobrevivencia;
    public Text TextoPontuacao;
    public Text quantidadeZumbi;
    private float tempoPontuacao;
    private int Kills = 0;


    void Start()
    {

        controlaUsuario = GameObject.FindWithTag("Player").GetComponent<UserController>();
        SliderVidaJogador.maxValue = 100;
        SliderVidaJogador.value = 100;
        LifeText.text = "100";
        Time.timeScale = 1;
        tempoPontuacao = PlayerPrefs.GetFloat("PontuacaoMaxima");
    }


    public void lifeaAndShieldRefresh()
    {


        Debug.Log(controlaUsuario.statusJogador.Vida);
        LifeText.text = controlaUsuario.statusJogador.Vida.ToString();
        SliderVidaJogador.value = controlaUsuario.statusJogador.Vida;
        MunicaoText.text = ControlaArma.Municao.ToString();

        if (ControlaArma.Municao == 0)
        {
            MunicaoText.text = "30";
        }
    }
        
    public void GameOver()
    {
        PainelDeGameOver.SetActive(true);
        Time.timeScale = 0;

        int minutos = (int)(Time.timeSinceLevelLoad / 60);
        int segundos = (int)(Time.timeSinceLevelLoad % 60);

        TextoSobrevivencia.text = "Você sobreviveu " + minutos + "min e " + segundos + "s.";

        PontuacaoMaxima(minutos,segundos);
    }

    void PontuacaoMaxima(int minutos, int segundos)
    {
        if (Time.timeSinceLevelLoad > tempoPontuacao)
        {
            tempoPontuacao = Time.timeSinceLevelLoad;
            TextoPontuacao.text = "Seu melhor tempo é "+minutos+"min e "+segundos+"s.";
            PlayerPrefs.SetFloat("PontuacaoMaxima", tempoPontuacao);
        }
        if(TextoPontuacao.text == "")
        {
            minutos = (int)(tempoPontuacao) / 60;
            segundos = (int)(tempoPontuacao) % 60;
            TextoPontuacao.text = "Seu melhor tempo é " + minutos + "min e " + segundos + "s.";
        }
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Cenario");
        controlaUsuario.VoltarAtivo();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AumentarKills()
    {
        Kills++;
        quantidadeZumbi.text = "X " + Kills;
    }
}
