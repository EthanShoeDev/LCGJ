using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnTimer : MonoBehaviour
{

    public float TimeBeforeDespawn = 20f;
    public bool DespawnAfterAnim = false;

    private float timeLeft;

    void OnEnable()
    {
        timeLeft = TimeBeforeDespawn;
    }

    // Use this for initialization
    void Start ()
	{
	    timeLeft = TimeBeforeDespawn;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if(timeLeft <= 0)
            SimplePool.Despawn(transform.gameObject);
        else
	        timeLeft -= Time.deltaTime;
    }

    public void AnimationFinish()
    {
        if(DespawnAfterAnim)
            SimplePool.Despawn(transform.gameObject);
    }
}
