using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoPersonagem : MonoBehaviour
{

    private Animator meuAnimator;

    private void Awake()
    {
        meuAnimator = GetComponent<Animator>();
    }


    public void Atacar(bool estado)
    {
        GetComponent<Animator>().SetBool("Ataque", estado);
    }

    public void Movimentar(float valorDeMovimento)
    {
        meuAnimator.SetFloat("Movendo", valorDeMovimento);
    }

    public void Morrer()
    {
        meuAnimator.SetTrigger("morrer");
    }
}
