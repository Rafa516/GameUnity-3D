﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamera : MonoBehaviour
{
    public GameObject Jogador;
    Vector3 dif;


    void Start()
    {
        dif = transform.position - Jogador.transform.position;
    }


    void Update()
    {

        transform.position = Jogador.transform.position + dif;
    }
}
