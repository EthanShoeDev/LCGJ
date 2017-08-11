using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float Damage = 10f;
    public float MoveSpeed = 5f;


    private Animator anim;
    private bool isMoving = true;
    private bool hasExploded = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        isMoving = true;
        hasExploded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
            transform.Translate(new Vector3(0, -MoveSpeed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player") && !col.CompareTag("Projectile") && !col.CompareTag("Bumper") && !hasExploded)
        {
            EnemyDmgHandler dmgHandler = col.transform.gameObject.GetComponent<EnemyDmgHandler>();
            if (dmgHandler != null)
                dmgHandler.Health -= Damage;
            hasExploded = true;
            isMoving = false;
            anim.SetTrigger("Explode");
        }
    }
}


