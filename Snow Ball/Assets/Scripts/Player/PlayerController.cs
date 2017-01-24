using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    

    //CAMPOS PLAYER-----------------------------------------------------------------------------------------------------------------------------

    //Rigidbody donde luego cargaremos el rigidbody de player
    private Rigidbody rbPlayer;

    //Navmesh de player
    private NavMeshAgent agentPlayer;

    //Guarda el valor segun si el jugador a tocado el player o no.
    private bool hitPlayer = false;

    //CAMPOS SERIALIZADOS-----------------------------------------------------------------------------------------------------------------------

    //Cadencia de disparo.
    [SerializeField] private float fireRate = 0;
    //Bala que se instancia.
    [SerializeField]
    private Bullet bullet;
    //GameObject donde se instanciara la bala.
    [SerializeField]
    private Transform firePoint;
    //Municion.
    [SerializeField] private int ammunition = 0;

    //VARIABLES PUBLICAS--------------------------------------------------------------------------------------------------------------------------

    //Vida del jugador.
    public int life=3;

    //VARIABLES PRIVADAS--------------------------------------------------------------------------------------------------------------------------

    private  Vector3 moveZone;
    //Valor que se usa para comparar con Time.time.
    private float timeToFire = 0;
    //Finger touch
    private Vector3 fTouch;

    void Start()
    {
        //Cargamos el RigidBody de player en la variable.
        rbPlayer = this.gameObject.GetComponent<Rigidbody>();

        //Cargamos el NavMesh de player.
        agentPlayer = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            switch (Input.GetTouch(0).phase)
            {
                #region TouchPhase Began
                case TouchPhase.Began:
                    Vector3 touchPositionB = Input.GetTouch(0).position;
                    if (!FingerHit(touchPositionB))
                    {
                        float dist = Mathf.Min(Vector3.Distance(this.transform.position,CameraHit(touchPositionB)));
 

                        if (fireRate == 0)
                        {
                            LookAtTouch(touchPositionB);
                            Shoot(dist,CameraHit(touchPositionB));
                        }
                        else
                        {
                            if (Time.time > timeToFire)
                            {
                                LookAtTouch(touchPositionB);
                                timeToFire = Time.time + 1 / fireRate;
                                Shoot(dist, CameraHit(touchPositionB));
                            }
                        }
                    }else
                    {
                        agentPlayer.SetDestination(moveZone);
                    }
                    break;
                #endregion

                #region TouchPhase Ended
                case TouchPhase.Ended:
                    hitPlayer = false;
                    break;
                #endregion
            }
        }
    }

    //Comprueba si  el dedo esta tocando al Player
    bool FingerHit(Vector3 touchXYZ)
        { 
        Ray ray = Camera.main.ScreenPointToRay(touchXYZ);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("MoveZone"))
            {
                moveZone = hit.transform.position;
                hitPlayer = true;
            }
            
        }

        return hitPlayer;
    }

    //Lugar donde estas posicionando el dedo
    Vector3 CameraHit(Vector3 touchXYZ)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchXYZ);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            fTouch = hit.point;

        }

        Vector3 tempTouch = fTouch - this.transform.position;

        tempTouch.y = 0;

        tempTouch = this.transform.position + tempTouch;

        return  tempTouch;

    }

    //Hace que el player gire en cualquier dirección
    void LookAtTouch(Vector3 touchXYZ)
    {

        Vector3 tempTouch = CameraHit(touchXYZ);

        this.transform.LookAt(tempTouch, Vector3.up);
    }

    //Instancia el prefab bullet
    void Shoot(float dist, Vector3 touchXYZ)
    {
       Bullet bTemp = Instantiate(bullet, firePoint.position, firePoint.rotation);
        bTemp.ballMagnitude = dist;
        bTemp.targetPos = touchXYZ;
    }
}
