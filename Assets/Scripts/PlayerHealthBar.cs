using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {

    public float Health
    {
        get { return controller.PlayerHealth; }
        set
        {
            controller.PlayerHealth = value;
            if (controller.PlayerHealth < 0)
                controller.PlayerHealth = 0;
            if (controller.PlayerHealth > controller.MaxHealth)
                controller.PlayerHealth = controller.MaxHealth;
            forgroundImg.fillAmount = controller.PlayerHealth / controller.MaxHealth;
        }
    }

    private GameController controller;
    private Image forgroundImg;

	// Use this for initialization
	void Start ()
	{
        controller = GameController.Instance;
	    forgroundImg = transform.GetChild(0).GetComponent<Image>();
	    Health = controller.PlayerHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
