using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiZumbi : MonoBehaviour
{
    public float Destruir;
    private float contador = 0;
    private float distanciaDestruir = 200;
    public GameObject Jogador;

    private void Start()
    {
        Jogador = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        contador += Time.deltaTime;

        if (contador >= Destruir)
        {
            if (Vector3.Distance(transform.position, Jogador.transform.position) > distanciaDestruir)
            {
                Destroy(gameObject);
            }
        }


    }
}
