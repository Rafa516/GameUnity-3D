using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
public class Move : MonoBehaviour {
 
    public float velocidadeFrente;
    public float velocidadeTras;
    public float velocidadeLados;
    private  Rigidbody meuRigidbody;
    //Metodo Start e executado uma unica vez, quando o script e executado.
    void Start () {
    
    }
 
    //Medodo Update e executado a cada Frame
    void Update () {
        if(Input.GetKey ("w") || Input.GetKey("up")){
            transform.Translate(0, 0, ( velocidadeFrente * Time.deltaTime)); //frente
        }
 
        if(Input.GetKey ("s") || Input.GetKey("down"))
        {
            transform.Translate(0, 0, (-velocidadeTras * Time.deltaTime));  //baixo
        }
 
        if(Input.GetKey ("a") || Input.GetKey("left"))
        {
            transform.Translate((-velocidadeLados * Time.deltaTime),0, 0);     //lado(diagonal)
        }
         
        if(Input.GetKey ("d")|| Input.GetKey("right"))
        {
            transform.Translate((velocidadeLados * Time.deltaTime),0, 0);      //lado
        }
    }
}