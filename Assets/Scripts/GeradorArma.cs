using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorArma: MonoBehaviour {

    public GameObject Arma;
    private float contador = 0;
    public float TempoGerarArmas;                 //Tempo para gerar um aviao
   public float TempoDestruir;                         //tempo de destruir o gerador	

	void Start () {
      
	}
	
	void Update () {
       
        contador += Time.deltaTime;

        if((contador >= TempoGerarArmas))
        {
            Instantiate(Arma, transform.position, transform.rotation);       //gerando mais armas
            contador = 0;
            
        }

         Destroy(gameObject,TempoDestruir);                 //destruindo a arma que n foi coletada durante o tempo limite.
	}
       

}
