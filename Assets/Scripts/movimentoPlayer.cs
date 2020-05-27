using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPlayer : MonoBehaviour
{
    public float speed = 18;
    private Rigidbody meuRigidbody;

    void Start()
    {
        meuRigidbody = GetComponent<Rigidbody>();
    }

   void update()
   {
       float hAxis = Input.GetAxis("Horizontal");
      float vAxis = Input.GetAxis("Vertical");

      Vector3 movement = new Vector3 (hAxis,0,vAxis) * speed * Time.deltaTime;
    

    meuRigidbody.MovePosition(transform.position + movement);
   }

} 
