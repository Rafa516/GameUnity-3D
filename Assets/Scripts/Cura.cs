using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cura : MonoBehaviour {
public float velRotacao;
public AudioClip FiringSound;
public float Destruir; 
public InterfaceScript scriptControlaInterface;
public Status statusJogador;
private int Curar; 

public void OnCollisionEnter(Collision col)         //função de colisão
{
  
    if ((col.gameObject.tag == "Player") && (statusJogador.Vida < 100 ))                 //condição para gerar o som de curar e a cura
    {

           AudioController.instance.PlayOneShot(FiringSound);      //som de curar

            if (statusJogador.Vida <= 60)
            {
                Curar = 40;
            }                                                               // Condição para não estrapolar o valor limite da vida (100)
            else
            {
                Curar = 100 - statusJogador.Vida;
            }

           statusJogador.Vida += Curar;                          //Incremento da cura
           scriptControlaInterface.lifeaAndShieldRefresh();      // Cura na interface na barra de vida.
		   Destroy(gameObject,Destruir);                       //item desaparece
    }
}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	
		GetComponent<Rigidbody>().transform.Rotate(0,velRotacao *Time.deltaTime,0,Space.World);    //girar item
	   
 }

}