using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MaxSpeed = 3f;
    [HideInInspector] public Vector3 DirectionFacing;

    private Animator anim;
    private Rigidbody2D rigid;

	// Use this for initialization
	void Start ()
	{
	    anim = GetComponent<Animator>();
	    rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    Vector3 velocity = new Vector3
	    {
	        x = Input.GetAxisRaw("Horizontal") * MaxSpeed,
	        y = Input.GetAxisRaw("Vertical") * MaxSpeed,
	        z = transform.position.z
	    };
	    rigid.velocity = velocity;

	    Vector3 scale = transform.localScale;
	    if (velocity.x < 0 && Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
	    {
	        scale.x = -Mathf.Abs(scale.x);
            DirectionFacing = Vector3.left;
	        anim.SetBool("isHorizontal", true);
        }
        else if(velocity.x > 0 && Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
	    {
	        scale.x = Mathf.Abs(scale.x);
            DirectionFacing = Vector3.right;
            anim.SetBool("isHorizontal", true);
        }
        //Need Sprite For When Wizard Faces Camera
	    if (velocity.y < 0)
	    {
	        if (Mathf.Abs(velocity.x) < Mathf.Abs(velocity.y))
	        {
	            scale.x = Mathf.Abs(scale.x);
                DirectionFacing = Vector3.down;
	            anim.SetBool("isHorizontal", false);
            }
            anim.SetBool("isFacing", true);
        }
        else if(velocity.y > 0 && Mathf.Abs(velocity.x) < Mathf.Abs(velocity.y))
	    {
	        scale.x = Mathf.Abs(scale.x);
            DirectionFacing = Vector3.up;
	        anim.SetBool("isHorizontal", false);
        }

        if (DirectionFacing != Vector3.down)
	        anim.SetBool("isFacing", false);

	    transform.localScale = scale;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Bumper") || col.otherCollider.CompareTag("Bumper"))
        {
            Physics2D.IgnoreCollision(col.collider, col.otherCollider);
        }
    }
}
