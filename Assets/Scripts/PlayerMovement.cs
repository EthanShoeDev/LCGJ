using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MaxSpeed = 3f;
    [HideInInspector] public Vector3 DirectionFacing;

    private Animator anim;

	// Use this for initialization
	void Start ()
	{
	    anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 velocity = new Vector3
	    {
	        x = Input.GetAxis("Horizontal") * MaxSpeed * Time.deltaTime,
	        y = Input.GetAxis("Vertical") * MaxSpeed * Time.deltaTime,
	        z = transform.position.z
	    };
	    transform.position += velocity;

	    Vector3 scale = transform.localScale;
	    if (velocity.x < 0)
	    {
	        scale.x = -Mathf.Abs(scale.x);
            DirectionFacing = Vector3.left;
        }
        else if(velocity.x > 0)
	    {
	        scale.x = Mathf.Abs(scale.x);
            DirectionFacing = Vector3.right;
        }
        transform.localScale = scale;

        //Need Sprite For When Wizard Faces Camera
	    if (velocity.y < 0)
	    {
	        DirectionFacing = Vector3.down;
	    }
	    else if(velocity.y > 0)
	    {
	        DirectionFacing = Vector3.up;
	    }

        if (velocity != Vector3.zero)
	    {
	        if (Mathf.Abs(velocity.x) >= Mathf.Abs(velocity.y))
	            anim.SetBool("isHorizontal", true);
	        else
	            anim.SetBool("isHorizontal", false);
	    }
    }
}
