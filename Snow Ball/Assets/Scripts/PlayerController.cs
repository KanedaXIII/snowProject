using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //touchWait
    int touchWait = 64;

    //Camera Main Transform

    Transform camTrans ;

    Transform myTrans;

    //Finger touch

    private Vector3 fTouch;

    //Cadencia de disparo.
    public float fireRate = 0;
    //Desfase en el apuntado.
    public float offSetDegree = 90;

    //Bala que se instancia.
    public Transform bullet;
    //GameObject donde se instanciara la bala.
    public Transform firePoint;
    public LayerMask notToHit;

    //Municion.
    public int ammunition = 0;

    //Valor que se usa para comparar con Time.time.
    float timeToFire = 0;


    // Use this for initialization
    void Start () {
        camTrans = Camera.main.transform;
        myTrans = this.transform;
    }
	
	// Update is called once per frame
	void Update () {
        
            if (fireRate == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Shoot();
                }
            }
            else
            {
                if (Input.GetMouseButton(0) && Time.time > timeToFire)
                {
                    timeToFire = Time.time + 1 / fireRate;
                    Shoot();
                }
            }
            

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            LookAtTouch(touchDeltaPosition);
            Debug.Log("Funciona");

            if (fireRate == 0)
            {
               
                    Shoot();
                
            }
            else
            {
                if ( Time.time > timeToFire)
                {
                    timeToFire = Time.time + 1 / fireRate;
                    Shoot();
                }
            }
           
        }

        
    }

    void LookAtTouch(Vector3 touchXYZ)
    {

        Vector3 tempTouch = new Vector3(touchXYZ.x,touchXYZ.y, camTrans.position.y - myTrans.position.y);

          fTouch = Camera.main.ScreenToWorldPoint(tempTouch);

        fTouch.y = myTrans.position.y;

        myTrans.LookAt(fTouch);
    }


   

    void Shoot()
    {
       Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
