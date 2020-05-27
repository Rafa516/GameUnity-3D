using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaBala : MonoBehaviour
{
    public float Speed = 10;
    public GameObject Inimigo;
    public int danoBala;
  //  Rigidbody inimigoRigidbody;


    private void Start()
    {
        danoBala = 1;


    }
    void Update()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * Speed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider colliderObject)
    {
        if (colliderObject.tag == "Inimigo")
        {
            Object.Destroy(gameObject);
            colliderObject.GetComponent<ZombieController>().TomarDano(danoBala);
            
        }
        Object.Destroy(gameObject);
    }
}


