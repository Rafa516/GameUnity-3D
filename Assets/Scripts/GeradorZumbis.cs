using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour
{

    public GameObject Zumbi;
    private float contador = 0;
    public float TempoGerarZumbis = 4;
    public LayerMask LayerZumbi;
    private float distanciaGeracao = 10;
    private float distanciaJogadorGeracao = 20;
    private GameObject jogador;

    private void Start()
    {
        jogador = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, jogador.transform.position) > distanciaJogadorGeracao)
        {
            contador += Time.deltaTime;

            if (contador >= TempoGerarZumbis)
            {
                StartCoroutine(GerarZumbi());
                contador = 0;
            }
        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaGeracao);
    }

    IEnumerator GerarZumbi()
    {
        Vector3 posicaoCriacao = AleatorizarPosicao();
        Collider[] colisores = Physics.OverlapSphere(posicaoCriacao, 1, LayerZumbi);

        while (colisores.Length > 0)
        {
            posicaoCriacao = AleatorizarPosicao();
            colisores = Physics.OverlapSphere(posicaoCriacao, 1, LayerZumbi);
            yield return null;
        }

        Instantiate(Zumbi, posicaoCriacao, transform.rotation);
    }

    Vector3 AleatorizarPosicao()
    {
        Vector3 posicao = Random.insideUnitSphere * distanciaGeracao;
        posicao += transform.position;
        posicao.y = 0;
        return posicao;
    }
}

