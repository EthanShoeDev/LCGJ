using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Left, Right, Up, Down
}

public class RepeatingBck : MonoBehaviour
{

    public float Speed = 5f;
    public Direction ScrollDirection = Direction.Left;
    [HideInInspector] public bool isDupl = false;
    [HideInInspector] public Vector3 startPos;

    private float dist;
    private RepeatingBck orgin;

	// Use this for initialization
	void Start ()
	{
	    startPos = transform.position;
	    SpriteRenderer rend = GetComponent<SpriteRenderer>();
	    if (ScrollDirection == Direction.Left || ScrollDirection == Direction.Right)
	        dist = rend.size.x;
	    else
	        dist = rend.size.y;
        if (!isDupl)
	    {
	        GameObject dupl = Instantiate(gameObject, transform.position, Quaternion.identity, transform.parent);
	        RepeatingBck script = dupl.GetComponent<RepeatingBck>();
	        script.isDupl = true;
	        script.orgin = this;
	        switch (ScrollDirection)
	        {
	            case Direction.Left:
	                dupl.transform.Translate(dist, 0, 0);
	                break;
	            case Direction.Right:
	                dupl.transform.Translate(-dist, 0, 0);
	                break;
	            case Direction.Up:
	                dupl.transform.Translate(0, -dist, 0);
	                break;
	            case Direction.Down:
	                dupl.transform.Translate(0, dist, 0);
	                break;
            }
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (isDupl)
            Speed = orgin.Speed;
        float travelDis = Mathf.Repeat(Time.time * Speed, dist);
        Vector3 newPosition = startPos;
        switch (ScrollDirection)
        {
            case Direction.Left:
                newPosition = startPos + Vector3.left * travelDis;
                break;
            case Direction.Right:
                newPosition = startPos + Vector3.right * travelDis;
                break;
            case Direction.Up:
                newPosition = startPos + Vector3.up * travelDis;
                break;
            case Direction.Down:
                newPosition = startPos + Vector3.down * travelDis;
                break;
        }
        transform.position = newPosition;
    }
}
