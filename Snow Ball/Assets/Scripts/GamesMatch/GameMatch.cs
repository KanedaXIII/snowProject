using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMatch : MonoBehaviour {

    //Nombre del nivel
    public string levelName;

    public typeMatchList typeMatch;

    //Puntuación que hay que igualar o superar
    public float scoreGoal;

    public CountDown stopWatch;

    #region Variables de contador de tiempo
    [Header("Time")]
    public float maxTime;

  
    private bool timeOut = false;
    #endregion

    #region Variables de contador de intentos
    [Header("Tries")]

    public int ballTries;
    #endregion

    #region Variables de Score, SuccesCheck, Etc... (No Inspector)
    [HideInInspector]
    //Comprueba si se ha superado la condición de victoria del nivel
    public bool successCheck;

    [HideInInspector]
    public float score;

    private bool paused;
    #endregion

    public enum typeMatchList{
        TimeMode,
        BallMode,
        InfMode
    }
    
        void Start()
        {

            successCheck = false;

            switch (typeMatch)
            {
                case typeMatchList.TimeMode:
                this.gameObject.AddComponent<CountDown>();
                stopWatch.OnTime += CheckTime;
                    break;
                case typeMatchList.BallMode:
                    break;
                case typeMatchList.InfMode:
                    break;
            }
            
        }

    public void CheckTime()
    {
        timeOut = true;
    }

    public void CheckScore()
    {

    }

    public void ShowSuccesUI()
    {

    }

    public void ShowGameOverUI()
    {

    }

    public void PauseForSeconds(float seconds)
    {
        this.StartCoroutine(this.PauseCorroutine(seconds));
    }

    private IEnumerator PauseCorroutine(float seconds)
    {
        this.paused = true;
        float time = 0.0f;
        while (time < seconds)
        {
            time += Time.deltaTime;
            yield return null;
        }
        this.paused = false;
    }
}

    
