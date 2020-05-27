using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorAviao : MonoBehaviour {

    public GameObject Aviao;
    private float contador = 0;
    public float TempoGerarAvioes;                 //Tempo para gerar um aviao
                            //Ajuste no tempo para destruir o avião

	void Start () {
      
	}
	
	void Update () {
       
        contador += Time.deltaTime;

        if(contador >= TempoGerarAvioes)
        {
            Instantiate(Aviao, transform.position, transform.rotation);       //gerando mais aviões 
            contador = 0;
        }


	}
        

}
        
	

