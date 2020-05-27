using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzSemaforo : MonoBehaviour 
{
 public Light light; 
 private float timer = 1; 
 
 void Start () {
		
	}

 void Update () { 
    timer -= Time.deltaTime;

if(timer < 0){
      light.enabled = !light.enabled;
      timer = 0.5f;                       //quanto menor o valor maior a velocidade do tempo entre aceso e apagado.
     }
   }
}