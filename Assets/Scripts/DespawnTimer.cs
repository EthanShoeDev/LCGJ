using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnTimer : MonoBehaviour
{

    public float TimeBeforeDespawn = 20f;
    public bool DespawnAfterAnim = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    TimeBeforeDespawn -= Time.deltaTime;
        if(TimeBeforeDespawn <= 0)
            SimplePool.Despawn(transform.gameObject);
	}

    public void AnimationFinish()
    {
        if(DespawnAfterAnim)
            SimplePool.Despawn(transform.gameObject);
    }
}
