using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Static Variables
    public float speed = 7f;

    void Update()
    {
        //Move functions
        //Horizontal & Vertical are Untiy defaults for wasd & arrows
        var moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        //Actual movement
        transform.Translate(moveHorizontal, 0, moveVertical, Space.World);


        //Turning around uses the mouse
        //This does NOT effect the direction you're moving
        RaycastHit mousePos;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out mousePos, 100))
        {
            transform.LookAt(new Vector3(mousePos.point.x, transform.position.y, mousePos.point.z));
        }

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    public GameObject projectile;
    public float fireRate;
    float nextFire;

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            SimplePool.Spawn(projectile, transform.position + transform.forward, transform.rotation);
        }
    }
    
}

