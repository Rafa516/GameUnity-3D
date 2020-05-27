using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiscarCoracao : MonoBehaviour {

    public Status statusJogador;
    public GameObject ImageCoracao;
   


    void Start()
    {
        InvokeRepeating("P", 0.5f, 0.5f);

    }

    void P()
    {
        if (statusJogador.Vida <= 50)
        {

            if (!ImageCoracao.activeInHierarchy)
                ImageCoracao.SetActive(true);                             // Condição para o coração piscar
            else
              if (ImageCoracao.activeInHierarchy)
                ImageCoracao.SetActive(false);
           
        }
        else
        {
            ImageCoracao.SetActive(true);
        }
    }

}
