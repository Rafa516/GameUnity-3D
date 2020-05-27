using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour, IMatavel
{

    public GameObject Jogador;
    public GameObject Bala;

    private Animator myAnimator;
    private Vector3 direct;
    public float Speed = 1;
    private Rigidbody meuRigidBody;
    private float distancia;

    private Transform myTransform;      //variaveis para checar movimento do zumbi
    private Vector3 lastPosition;
    public bool IsMoving;
    private MovingPerson scriptMovingPerson;

    public AnimacaoPersonagem animacaoInimigo;
    private Status statusInimigo;
    public InterfaceScript interfaceScript;
    private Vector3 posicaoAleatoria;
    public GameObject Arma;

    private float contadorVagar;
    private float tempoPosicoes = 4;
    private int tamanhoRaio = 30;



    void Start()
    {
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
        interfaceScript = GameObject.FindWithTag("Player").GetComponent<InterfaceScript>();
        scriptMovingPerson = GetComponent<MovingPerson>();
        IsMoving = true;
        meuRigidBody = GetComponent<Rigidbody>();
        animacaoInimigo = GetComponent<AnimacaoPersonagem>();
        statusInimigo = GetComponent<Status>();
        Jogador = GameObject.FindWithTag("Player");
        interfaceScript = GameObject.FindObjectOfType(typeof(InterfaceScript)) as InterfaceScript;
    }

    void FixedUpdate()
    {

        distancia = Vector3.Distance(Jogador.transform.position, transform.position);
        Quaternion rotation = Quaternion.LookRotation(direct);

        meuRigidBody.MoveRotation(rotation);   //vendo se o zumbi esta parado ou andando, se ele estiver parado nao ira rotacionar

        animacaoInimigo.Movimentar(direct.magnitude);

        if (distancia > 30)
        {
            Vagar();
        }


        else if (distancia > 3)
        {
            direct = Jogador.transform.position - transform.position;
            scriptMovingPerson.Moving(direct, statusInimigo.VelocidadeInimigo);
            animacaoInimigo.Atacar(false);
        }
        else
        {
            direct = Jogador.transform.position - transform.position;
            animacaoInimigo.Atacar(true);                         //se o zumbi para de seguir o jogador eh pq esta do seu lado, portanto faz animacao de ataque
        }

    }
    void Vagar()
    {
        contadorVagar -= Time.deltaTime;
        if (contadorVagar <= 0)
        {
            posicaoAleatoria = aleatorizarPosicao();
            contadorVagar += tempoPosicoes;
        }

        bool ficouPerto = Vector3.Distance(transform.position, posicaoAleatoria) <= 5;

        if (ficouPerto == false)
        {
            direct = posicaoAleatoria - transform.position;
            scriptMovingPerson.Moving(direct, statusInimigo.VelocidadeInimigo);
        }


    }

    Vector3 aleatorizarPosicao()
    {
        Vector3 posicao = Random.insideUnitSphere * tamanhoRaio;
        posicao += transform.position;
        posicao.y = transform.position.y;
        return posicao;
    }

    void AtacaJogador()
    {
        int damage = Random.Range(28, 34);
        Jogador.GetComponent<UserController>().TomarDano(damage);
    }

    public void TomarDano(int dano)
    {
        statusInimigo.Vida -= dano;
        if (statusInimigo.Vida <= 0)
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        scriptMovingPerson.Morrer();
        animacaoInimigo.Morrer();
        interfaceScript.AumentarKills();
        int numero = Random.Range(0, 11);

        if(numero==1 || numero == 2)
        {
            Instantiate(Arma,transform.position,transform.rotation);
        }


        this.enabled = false;
        Destroy(gameObject, 1);
    }
}
