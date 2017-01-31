using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMatch : MonoBehaviour {

    //Nombre del nivel
    public string levelName;

    public typeMatchList typeMatch;
    
    #region Variables de contador de tiempo
    [Header("Time Mode")]
    public float maxTime;

    private float currentTime;
    #endregion

    #region Variables de Score, GameOver, Etc... (No Inspector)
    [HideInInspector]
    //Comprueba si se ha superado la condición de victoria del nivel
    public bool succesCheck;

    [HideInInspector]
    public bool gameOverCheck;

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
       
            succesCheck = false;

            gameOverCheck = false;



        }

        // Update is called once per frame
        void Update () {



            if (succesCheck)
            {
                Debug.Log("Guarda los datos cuando gana");
            }else if (gameOverCheck)
            {
                Debug.Log("Guarda los datos cuando pierde");
            }

	    }

    public void showSuccesUI()
    {

    }

    public void showGameOverUI()
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

    
