using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfiniteM : MonoBehaviour {

    //Lista de posiciones de spawn.
    [SerializeField]
    private List<Transform> lSpawns;

    //Lista de enemigos.
    [SerializeField]
    private List<Transform> lEnemies;

    //Numero de enemigos actuales del nivel.
    private int nUpdateEnemies;

    //Numero de enemigos totales del nivel.
    private int nEnemies;

    //Numero de nivel.
    private int nLevel;

    //Puntuación del nivel.
    [HideInInspector]
    public int score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
