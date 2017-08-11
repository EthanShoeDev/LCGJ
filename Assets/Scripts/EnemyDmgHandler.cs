using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding.Util;
using UnityEngine;

public class EnemyDmgHandler : MonoBehaviour
{
    public float Health
    {
        get
        {
            if (healthBar != null)
                return healthBar.Health;
            else
            {
                throw new NotSupportedException();
                return -9999f;
            }
        }
        set
        {
            healthBar.Health = value;
            if (Health <= 0)
            {
                Destroy(transform.gameObject);
                SimplePool.Spawn(AshEffect, transform.position, Quaternion.identity);
            }
        }
    }

    public List<Vector3> AttackPoints;
    public float AttackDamage = 5f;
    public float AttackDist = 0.5f;
    public float AttackCooldown = 1.5f;
    public GameObject AshEffect;

    private float coolDownRemaining;
    private SmallHealthBar healthBar;
    private EnemyMovement movement;
    private PlayerDamage player;

    // Use this for initialization
    void Start()
    {
        healthBar = GetComponentInChildren<SmallHealthBar>();
        movement = GetComponent<EnemyMovement>();
        player = movement.target.GetComponent<PlayerDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, movement.target.position);
        foreach (Vector3 point in AttackPoints)
        {
            if (Vector2.Distance(transform.position + point, movement.target.position) <= AttackDist)
            {
                //Attack
                if (coolDownRemaining <= 0)
                {
                    player.Health -= AttackDamage;
                    coolDownRemaining = AttackCooldown;
                }
            }
        }
        if (coolDownRemaining >= 0)
            coolDownRemaining -= Time.deltaTime;
    }
}
