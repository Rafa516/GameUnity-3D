using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPerson : MonoBehaviour
{

    private Rigidbody meuRigidbody;
    private Status personagemStatus;

    private void Awake()
    {
        meuRigidbody = GetComponent<Rigidbody>();
    }

    public void Moving(Vector3 direct, float Speed)
    {
        meuRigidbody.MovePosition(meuRigidbody.position + direct.normalized * Speed * Time.deltaTime);
    }

    public void Morrer()
    {
        meuRigidbody.constraints = RigidbodyConstraints.None;
        meuRigidbody.velocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
    }
}
