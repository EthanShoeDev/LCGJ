using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{

    public float MoveSpeed = 5f;
    private Animator anim;
    private bool isMoving = true;
    private Collider2D[] colliders;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        colliders = GetComponents<Collider2D>();
    }

    void OnEnable()
    {
        isMoving = true;
        if (colliders != null)
        {
            foreach (Collider2D collider in colliders)
            {
                collider.enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
            transform.Translate(new Vector3(0, -MoveSpeed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player") && !col.CompareTag("Projectile") && !col.CompareTag("Bumper"))
        {
            foreach (Collider2D collider in colliders)
            {
                collider.enabled = false;
            }
            isMoving = false;
            anim.SetTrigger("Explode");
        }
    }

    public void ExplodeFinish()
    {
        SimplePool.Despawn(gameObject);
    }
}


