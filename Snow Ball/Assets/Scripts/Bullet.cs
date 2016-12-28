using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bullet_vel;

	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * bullet_vel);
    }
}
