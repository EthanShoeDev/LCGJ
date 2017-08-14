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
    void Start()
    {
        healthBar = PlayerHealthBar.gUI;
    }
}
