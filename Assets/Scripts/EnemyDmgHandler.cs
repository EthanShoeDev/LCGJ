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
                SimplePool.Despawn(transform.gameObject);
                GameObject ash = SimplePool.Spawn(AshEffect, transform.position, Quaternion.identity);
                if (AshParentObj != null)
                    ash.transform.parent = AshParentObj.transform;
            }
        }
    }

    public List<Vector3> AttackPoints;
    public float AttackDamage = 5f;
    public float AttackDist = 0.5f;
    public float AttackCooldown = 1.5f;
    public GameObject AshEffect;
    public GameObject AshParentObj;

    private float coolDownRemaining;
    private SmallHealthBar healthBar;
    private EnemyMovement movement;
    private PlayerDamage player;
    private Animator anim;

    void OnEnable()
    {
        Start();
    }

    // Use this for initialization
    void Start()
    {
        healthBar = GetComponentInChildren<SmallHealthBar>();
        movement = GetComponent<EnemyMovement>();
        anim = GetComponent<Animator>();
        if(movement.target != null)
            player = movement.target.GetComponent<PlayerDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null && movement.target != null)
            player = movement.target.GetComponent<PlayerDamage>();
        float dist = Vector3.Distance(transform.position, movement.target.position);
        foreach (Vector3 point in AttackPoints)
        {
            if (Vector2.Distance(transform.position + point, movement.target.position) <= AttackDist)
            {
                //Attack
                if (coolDownRemaining <= 0)
                {
                    if(player != null)
                        player.Health -= AttackDamage;
                    coolDownRemaining = AttackCooldown;
                    anim.SetTrigger("Attack");
                }
            }
        }
        if (coolDownRemaining >= 0)
            coolDownRemaining -= Time.deltaTime;
    }
}
