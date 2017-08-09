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

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
            transform.Translate(new Vector3(0, -MoveSpeed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        isMoving = false;
        anim.SetTrigger("Explode");
    }

    public void ExplodeFinish()
    {
        Destroy(this);
    }
}


