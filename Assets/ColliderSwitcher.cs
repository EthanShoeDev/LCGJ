using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimToCollider
{
    public GameObject ColliderObject;
    public string AnimName;
}

public class ColliderSwitcher : MonoBehaviour {

    public List<AnimToCollider> States;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
