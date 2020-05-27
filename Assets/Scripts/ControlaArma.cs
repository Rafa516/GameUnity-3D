using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    public GameObject Bala;
    public GameObject CanoArma;
    public AudioClip FiringSound;
    public AudioClip SemBala;
    public static int Municao;
    public float Destruir = 1;
    public int Mostrar;
    public InterfaceScript scriptControlaInterface;
    public Status statusJogador;

    //  private AudioController scriptAudioController;

    // Use this for initialization
    void Start()
    {
        Municao = 30;                             //Quantidade de Muniçao por arma
    }

    // Update is called once per frame
    void Update()
    {

        Mostrar = Municao;

        if (Input.GetButtonDown("Fire1"))                                  //quando clicar no mouse (atirar)
        {
            if (Municao > 0)
            {                                              // se a muniçao for maior que 0
                Instantiate(Bala, CanoArma.transform.position, CanoArma.transform.rotation);       // gera a bala 

                AudioController.instance.PlayOneShot(FiringSound);   //gera o som do tiro 

                Municao--;    //decremento de munição
                scriptControlaInterface.lifeaAndShieldRefresh(); // munição decrementando na interface(no texto de munição na camera)

                if (Municao <= 0)
                {                                         // se for menor que 0
                    AudioController.instance.PlayOneShot(SemBala);        //gera som de sem bala
                    Destroy(gameObject, Destruir);        // destroi a arma



                }
            }
        }
    }

}

