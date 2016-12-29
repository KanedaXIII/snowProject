using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {

    //Campos Enemy------------------------------------------------------------------------------------------------------------------------------------------------------

    private Rigidbody rbEnemy;

    //Campos Publicos----------------------------------------------------------------------------------------------------------------------------------------------------

    //Campos Serializados------------------------------------------------------------------------------------------------------------------------------------------------
    //Cadencia de disparo.
    [SerializeField]
    private float fireRate = 0;
    //Campos Privados----------------------------------------------------------------------------------------------------------------------------------------------------
    private GameObject PlayerEnemy;
    // Use this for initialization
    void Start () {
        PlayerEnemy = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(PlayerEnemy.transform);
	}
}
