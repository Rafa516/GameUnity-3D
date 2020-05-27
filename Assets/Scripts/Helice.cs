using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helice : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    
    transform.Rotate(new Vector3(0f, 180f, 0f)* Time.deltaTime);  //Girando a helice do avião  de acordo com angulo fixado no código.
		
	}
}
