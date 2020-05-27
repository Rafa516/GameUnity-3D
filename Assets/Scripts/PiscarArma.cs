using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiscarArma : MonoBehaviour {

   
    public GameObject ImageArma;



    void Start()
    {
        InvokeRepeating("P", 0.5f, 0.5f);

    }

    void P()
    {
        if (ControlaArma.Municao <= 10)
        {

            if (!ImageArma.activeInHierarchy)
                ImageArma.SetActive(true);                             // Condição para o coração piscar
            else
              if (ImageArma.activeInHierarchy)
                ImageArma.SetActive(false);

        }

    }

}