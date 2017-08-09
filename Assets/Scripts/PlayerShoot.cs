using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject Projectile;

    private Transform spawnPoint;
    private Animator anim;
    private PlayerMovement mov;

	// Use this for initialization
	void Start ()
	{
	    spawnPoint = transform.Find("ProjectileSpawn");
	    anim = GetComponent<Animator>();
	    mov = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetButtonDown("Fire1"))
	    {
	        //TODO: Add pooling
	        Quaternion rot = Quaternion.Euler(0, 0, 90);
            if (mov.DirectionFacing == Vector3.up)
                rot = Quaternion.Euler(0,0,180);
            else if(mov.DirectionFacing == Vector3.right)
                rot = Quaternion.Euler(0,0,90);
            else if(mov.DirectionFacing == Vector3.down)
                rot = Quaternion.Euler(0,0,0);
            else if(mov.DirectionFacing == Vector3.left)
                rot = Quaternion.Euler(0,0,-90);
	        Instantiate(Projectile, spawnPoint.position, rot);
            anim.SetTrigger("playerCast");
	    }
	}
}
