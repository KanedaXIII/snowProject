using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Range(0, -90)]
    private float angleShoot;

    [SerializeField]
    [Range(0, 100)]
    private float magnitutedOffSet;

    //Magnitud del proyectil.
    [HideInInspector]
    public float ballMagnitude;
    //Dirección del proyectil.
    [HideInInspector]
    public Vector3 targetPos;

    //Tiempo en el que tarda el proyectil en destruirse.
    [SerializeField]
    private float timeDestroy;

    private Rigidbody rbBullet;

    private Vector3 vectorDir;

    void Start()
    {
        rbBullet = this.GetComponent<Rigidbody>();

        vectorDir = (targetPos - this.transform.position).normalized;
        vectorDir = Quaternion.AngleAxis(angleShoot, this.transform.right) * vectorDir;
        rbBullet.AddForce(vectorDir * (ballMagnitude * magnitutedOffSet));
        rbBullet.useGravity = true;

    }

    // Update is called once per frame
    void Update()
    {

        timeDestroy -= Time.deltaTime;

        

        if (timeDestroy <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "dianaOut":

                break;
            case "dianaMiddle":

                break;
            case "dianaCenter":

                break;
        }
    }
}
