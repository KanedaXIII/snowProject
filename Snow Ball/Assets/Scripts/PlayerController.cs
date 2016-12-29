using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //CAMPOS PLAYER-----------------------------------------------------------------------------------------------------------------------------

    private Rigidbody rbPlayer;

    private bool hitPlayer = false;

    //CAMPOS SERIALIZADOS-----------------------------------------------------------------------------------------------------------------------

    //Cadencia de disparo.
    [SerializeField] private float fireRate = 0;
    //Bala que se instancia.
    [SerializeField]
    private Transform bullet;
    //GameObject donde se instanciara la bala.
    [SerializeField]
    private Transform firePoint;
    //Municion.
    [SerializeField] private int ammunition = 0;

    //VARIABLES PRIVADAS--------------------------------------------------------------------------------------------------------------------------

    //Valor que se usa para comparar con Time.time.
    private float timeToFire = 0;
    //Finger touch
    private Vector3 fTouch;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
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
                        LookAtTouch(touchPositionB);

                        if (fireRate == 0)
                        {
                            Shoot();
                        }
                        else
                        {
                            if (Time.time > timeToFire)
                            {
                                timeToFire = Time.time + 1 / fireRate;
                                Shoot();
                            }
                        }
                    }
                    break;
                #endregion

                #region TouchPhase Moved
                case TouchPhase.Moved:
                    Debug.Log("mueve");
                    Vector3 touchPositionM = Input.GetTouch(0).position;
                    Debug.Log(FingerHit(touchPositionM));
                    if (FingerHit(touchPositionM))
                    {
                        rbPlayer.MovePosition(CameraHit(touchPositionM));
                    }
                    break;
                #endregion

                case TouchPhase.Ended:
                    hitPlayer = false;
                    break;
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
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                hitPlayer = true;
            }
            
        }

        return hitPlayer;
    }

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
    void Shoot()
    {
       Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
