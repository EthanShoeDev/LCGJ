using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour {

    float speed = 7f;
    public float turnSpeed;
    

    void Update()
    {
        var moveHorizontal = Input.GetAxis("JLHorizontal") * Time.deltaTime * speed;
        var moveVertical = Input.GetAxis("JLVertical") * Time.deltaTime * speed;

        transform.Translate(moveHorizontal, 0, moveVertical, Space.World);


        Vector3 NextDir = new Vector3(Input.GetAxisRaw("JRHorizontal"), 0, Input.GetAxisRaw("JRVertical"));
        if (NextDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(NextDir);
            Shoot();
        }
    }
    public GameObject projectile;
    public float fireRate;
    float nextFire;
    void Shoot()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(projectile, transform.position + transform.forward, transform.rotation);
        }
        

    }
}
