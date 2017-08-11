using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmgHandler : MonoBehaviour
{
    public float Health
    {
        get
        {
            if (healthBar != null)
                return healthBar.Health;
            else
            {
                throw new NotSupportedException();
                return -9999f;
            }
        }
        set { healthBar.Health = value; }
    }

    private SmallHealthBar healthBar;

	// Use this for initialization
	void Start ()
	{
	    healthBar = GetComponentInChildren<SmallHealthBar>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Projectile") && col.IsTouchingLayers(LayerMask.NameToLayer("Enemy")))
        {
            Health -= 10f;
            if(Health <= 0)
                Destroy(transform.gameObject);
        }
    }
}
