using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(GameMatch))]
public class DianaMatch : MonoBehaviour {

    private static DianaMatch instance = null;
    [Header("Kind of Diana Match")]
    public typeDianaList typeDiana;

    #region Puntos que da las dianas
    [Header("Diana Points")]
    public float dianaOut;

    public float dianaMiddle;

    public float dianaCenter;
    #endregion

   

    #region Variables de modo nivel por tiempo
    [Header("Level Time")]
    //Puntuación que hay que igualar o superar
    public float scoreGoal;

    [HideInInspector]
    public bool modeTimeOn = false;

    #endregion

    #region Variables de modo nivel por limite de bolas

    [HideInInspector]
    public bool modeBallOn = false;

    #endregion

    #region Variables de modo infinito
    [Header("Infinity")]
    public float dianaOutTime;

    public float dianaMiddleTime;

    public float dianaCenterTime;

    [HideInInspector]
    public bool modeInfOn = false;
    #endregion

    public enum typeDianaList
    {
        Infinity,
        LevelTime,
        LevelBall
    }

    public static DianaMatch Instance
    {
        get
        {
            return DianaMatch.instance;
        }
    }

    void Awake()
    {
      DianaMatch.instance = this;
    }

    // Use this for initialization
    void Start () {
        switch (typeDiana)
        {
            case typeDianaList.Infinity:
                modeInfOn = true;
                break;
            case typeDianaList.LevelTime:
                modeTimeOn = true;
                break;
            case typeDianaList.LevelBall:
                modeBallOn = true;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
