using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject Enemy;
    public GameObject EnemyParentObj;
    public float TimeToSpawn = 5f;
    public bool StartWithSpawned = true;

    private float timeLeft = 0f;

	// Use this for initialization
	void Start () {
	    if (StartWithSpawned)
	    {
	        GameObject enem = SimplePool.Spawn(Enemy, transform.position, Quaternion.identity);
	        if (EnemyParentObj != null)
	            enem.transform.parent = EnemyParentObj.transform;
	    }
	    timeLeft = TimeToSpawn;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (timeLeft <= 0)
	    {
	        GameObject enem = SimplePool.Spawn(Enemy, transform.position, Quaternion.identity);
	        if (EnemyParentObj != null)
	            enem.transform.parent = EnemyParentObj.transform;
	        timeLeft = TimeToSpawn;
	    }
	    else
	        timeLeft -= Time.deltaTime;
	}
}
