using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public List<GameObject> Projectiles;

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
	        SimplePool.Spawn(Projectiles[0], spawnPoint.position, RotationFromFacingDirection(mov.DirectionFacing));
            anim.SetTrigger("playerCast");
	    }
        if (Input.GetButtonDown("Fire2"))
        {
            SimplePool.Spawn(Projectiles[1], spawnPoint.position, RotationFromFacingDirection(mov.DirectionFacing));
            anim.SetTrigger("playerCast");
        }
    }

    private Quaternion RotationFromFacingDirection(Vector3 Direction)
    {
        Quaternion rot = Quaternion.Euler(0, 0, 90);
        if (Direction == Vector3.up)
            rot = Quaternion.Euler(0, 0, 180);
        else if (Direction == Vector3.right)
            rot = Quaternion.Euler(0, 0, 90);
        else if (Direction == Vector3.down)
            rot = Quaternion.Euler(0, 0, 0);
        else if (Direction == Vector3.left)
            rot = Quaternion.Euler(0, 0, -90);
        return rot;
    }
}
