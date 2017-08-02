using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;

    public float maxHealth = 100f;
    
    private float _health = 100f;

    public float Health
    {
        get { return _health; }
        protected set
        {
            _health = value;
            if (fillImage != null)
            {
                fillImage.fillAmount = _health / maxHealth;
            }
        }
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(float value)
    {
        //Could be "poisoned" and take 110% dmg (or something similiar)
        Health -= value;
    }
}
