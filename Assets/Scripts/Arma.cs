using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {
public float velRotacao;
public AudioClip FiringSound;



public void OnCollisionEnter(Collision col)         //função de colisão
{
  
    if ((col.gameObject.tag == "Player") && (PegarArma.Ativador == true))                 //condição para gerar o som de pegar arma
    {

           AudioController.instance.PlayOneShot(FiringSound);      //som de pegar arma
		   
    }
}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	
		GetComponent<Rigidbody>().transform.Rotate(0,velRotacao *Time.deltaTime,0,Space.World);    //girar arma
	   
 }

}
