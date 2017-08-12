using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
            GameController.Instance.LoadScene(GameController.Instance.CurrentLevelIndex+1);
    }
}
