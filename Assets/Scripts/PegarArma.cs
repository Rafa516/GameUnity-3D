using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarArma : MonoBehaviour
{

    public Transform mao;
    public static bool Ativador;
    public GameObject MunicaoTexto;
    public ControlaArma ControlaArma;

    void Start()
    {
        Ativador = true;
        ControlaArma = GetComponent<ControlaArma>();
    }

    public void OnCollisionEnter(Collision col)                            //funçao de colisão
    {

        if (col.gameObject.tag == "Arma")                                //condiçao para pegar meu objeto(arma)
        {
            if (Ativador == true)
            {
                //col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                col.gameObject.GetComponent<BoxCollider>().enabled = false;                //quando eu pego a arma o boxcollider dela desativa
                col.gameObject.GetComponent<Arma>().enabled = false;              //quando eu pego a arma o script Arma e desativado
                col.gameObject.GetComponent<ControlaArma>().enabled = true;      //quando eu pego a arma o Script ControlaArma e ativado.
                col.transform.position = mao.position;
                col.transform.rotation = mao.rotation;                       //local em que  a arma vai ficar(maõ)

                col.transform.SetParent(mao);

                Ativador = false;
            }
           

        }
    }
    void Update()
    { 

          if(ControlaArma.Municao <= 0)
               Ativador = true;

         if(Ativador == true)
            {
            MunicaoTexto.gameObject.SetActive(false);
            }
        else
            {
            MunicaoTexto.gameObject.SetActive(true);
            }
    }

}
