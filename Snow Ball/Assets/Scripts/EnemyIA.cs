using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using Extensions.System.Colections;

public class EnemyIA : MonoBehaviour {

    //Campos Enemy------------------------------------------------------------------------------------------------------------------------------------------------------
    
    //Rigidbody de Enemy.
    private Rigidbody rbEnemy;
    //NavMeshAgent de Enemy.
    private NavMeshAgent agent;
    //Lugar actual.
    string updatedPlace;

    //Campos Publicos----------------------------------------------------------------------------------------------------------------------------------------------------

    //Campos Serializados------------------------------------------------------------------------------------------------------------------------------------------------

    //Punto donde hara spawn la bola de nieve.
    [SerializeField]
    private Transform firePoint;
    //Nuestro proyectil o bola de nieve.
    [SerializeField]
    private Transform bullet;
    //Cadencia de disparo.
    [SerializeField]
    private float fireRate = 0;
    //Lista de posiciones de los enemigos.
    [SerializeField]
    private List<Transform> lTransforms;
    //Tiempo minimo en el que tarda de cambiar de posición un enemigo.
    [SerializeField]
    private float timeMinMove = 2;
    //Tiempo maximo en el que tarda de cambiar de posición un enemigo.
    [SerializeField]
    private float timeMaxMove = 5;
    //Tiempo minimo en el que tarda en disparar al jugador.
    [SerializeField]
    private float timeMinShoot;
    //Tiempo máximo en el que tarda en disparar al jugador.
    [SerializeField]
    private float timeMaxShoot;
    //Campos Privados----------------------------------------------------------------------------------------------------------------------------------------------------
    //Random Move TIme.
    private float rTime;
    //Random Shoot Time.
    private float sTime;
    //PlayerTarget.
    private GameObject PlayerEnemy;

    // Use this for initialization
    void Start () {
        PlayerEnemy = GameObject.FindGameObjectWithTag("Player");

        agent = this.GetComponent<NavMeshAgent>();

        updatedPlace = "1st";

        rTime = UnityEngine.Random.Range(timeMinMove, timeMaxMove);

        sTime = UnityEngine.Random.Range(timeMinShoot, timeMaxShoot);

    }

    // Update is called once per frame
    void Update()
    {
        
        rTime -= Time.deltaTime;

       

        if (rTime < 0)
        {
            randomMove(lTransforms);
           
        }

        sTime -= Time.deltaTime;

        if (sTime < 0)
        {
            shootBullet();
        }

    }
    //Movimiento aleatorio de un jugador.
    public void randomMove(List<Transform> lTrans)
    {   
        rTime = UnityEngine.Random.Range(timeMinMove, timeMaxMove);
        randomPosition(lTrans);
    }
    //Posición aleatoria.
    public void randomPosition(List<Transform> lTrans)
    {

       Transform tTemp= lTrans.RandomItem<Transform>();

        while (tTemp.name.Equals(updatedPlace))
        {
            tTemp = lTrans.RandomItem<Transform>();
        }

        updatedPlace = tTemp.name;

        this.transform.LookAt(tTemp);

        agent.SetDestination(tTemp.position);

    }
    //Disparo del enemigo.
    public void shootBullet()
    {
        this.transform.LookAt(PlayerEnemy.transform);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        sTime = UnityEngine.Random.Range(timeMinShoot, timeMaxShoot);
    }





}
