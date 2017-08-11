using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {

    public float Health
    {
        get { return _health; }
        set
        {
            _health = value;
            if (_health < 0)
                _health = 0;
            if (_health > 100)
                _health = 100;
            forgroundImg.fillAmount = _health / 100f;
        }
    }

    private Image forgroundImg;

    private float _health = 100;

	// Use this for initialization
	void Start ()
	{
	    forgroundImg = transform.GetChild(0).GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
