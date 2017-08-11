using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    public bool GodMode = false;

    public float Health
    {
        get { return healthBar.Health; }
        set { healthBar.Health = value; }
    }

    private PlayerHealthBar healthBar;

	// Use this for initialization
	void Start ()
	{
        //This probably isnt the best solution
	    healthBar = GameObject.Find("Healthbar").GetComponent<PlayerHealthBar>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
