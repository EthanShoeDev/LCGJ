using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimToCollider
{
    public GameObject ColliderObject;
    public string AnimName;
    public bool AnimValue;
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
	    foreach (AnimToCollider state in States)
	    {
	        if(anim.GetBool(state.AnimName) == state.AnimValue)
                state.ColliderObject.SetActive(true);
            else
                state.ColliderObject.SetActive(false);
	    }
	}
}
