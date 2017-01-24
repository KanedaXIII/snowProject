using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance = null;

    public bool gameOverB = false;

    public static GameManager Instance
    {
        get
        {
            return GameManager.instance;
        }
    }


    void Awake()
    {
        if (GameManager.instance == null)
            GameManager.instance = this;
        else if (GameManager.instance != this)
            GameObject.Destroy(this.gameObject);
        // No destruir con los cambios de escena
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator gameOver()
    {
        yield return null;
    }
}
