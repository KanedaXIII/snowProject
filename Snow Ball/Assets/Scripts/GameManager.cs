using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [HideInInspector]
    public float scoreMatch;

    private static GameManager instance = null;

    private GamePersistentData gamePersistentData;

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

    //Método para cargar escenas o hacer reset
    public void loadiScene(string scn)
    {
        if (scn == "reset")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene(scn);
            
        }

    }

    // Métodos de guardado y carga de datos
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        this.LoadData();
    }
    
    public void LoadData()
    {
        // Cargar datos persistentes del juego
        if (PlayerPrefs.HasKey("GamePersistentData"))
        {
            string persistentData = PlayerPrefs.GetString("GamePersistentData");
            GameManager.Instance.gamePersistentData = JsonUtility.FromJson<GamePersistentData>(persistentData);
        }
        else
        {
            GameManager.Instance.gamePersistentData = new GamePersistentData();
        }
        
        // Cargar idioma actual del juego
        //if (PlayerPrefs.HasKey("Language"))
        //    GameManager.Instance.gameLanguage = PlayerPrefs.GetString("Language");
        //else
        //    GameManager.Instance.gameLanguage = "en";
    }
    
    public void SaveData()
    {
        // Guardar datos persistentes del juego
        string persistentDataString = JsonUtility.ToJson(GameManager.Instance.gamePersistentData);
        PlayerPrefs.SetString("GamePersistentData", persistentDataString);
        
        // Guardar idioma actual del juego
        //PlayerPrefs.SetString("Language", GameManager.Instance.gameLanguage);
    }
    
}
