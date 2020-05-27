
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviao : MonoBehaviour {

//private float contador = 0;
//public float TempoGerarAvioes;
public float velocidade;                       //Velocidade pode ser ajustada 
public float Destruir; 

	//void Start () {
		//TempoGerarAvioes = 5;
	//}
	

	void Update () {

		Vector3 pos = transform.position;
		pos.z = pos.z +(velocidade * Time.deltaTime);        //Movimentando o avião no eixo z.
		transform.position = pos;
		Destroy(gameObject,Destruir);  //DEstruindo o avião
	}
}
      

	
