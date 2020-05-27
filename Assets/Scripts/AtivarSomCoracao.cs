using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarSomCoracao : MonoBehaviour {

    public Status statusJogador;

		
	
	
	
	void Update () {

        if (statusJogador.Vida <= 50)
        {
            GetComponent<AudioSource>().enabled = true;
        }

        else
        {
            GetComponent<AudioSource>().enabled = false;
        }
	}
}
