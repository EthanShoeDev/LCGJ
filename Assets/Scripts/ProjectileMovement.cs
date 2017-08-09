using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{

    public float MoveSpeed = 5f;
    private Animator anim;
    private bool isMoving = true;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
            transform.Translate(new Vector3(0, -MoveSpeed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player") && !col.CompareTag("Projectile"))
        {
            isMoving = false;
            anim.SetTrigger("Explode");
        }
    }

    public void ExplodeFinish()
    {
        SimplePool.Despawn(gameObject);
    }
}


