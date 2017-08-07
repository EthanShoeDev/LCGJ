using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ProjectileMovement : MonoBehaviour {

    public float speed;
    float lifeTime;
    public float maxLifeTime; //How long a projectile travels before it dies
    void Update () {
                                  //"Speed" needs to be changed in Inspector
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        lifeTime += Time.deltaTime;

        if(lifeTime >= maxLifeTime)
        {
            Destroy(gameObject);
        }
	}
}
