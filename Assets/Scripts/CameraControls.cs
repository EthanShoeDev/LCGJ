using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

    Vector3 offset = new Vector3(0,6,-11);
    Vector3 rotation = new Vector3(22,0,0);
    public Transform player;

    private void Start()
    {
        transform.Rotate(rotation);
    }
    void Update () {
        transform.position = player.transform.position + offset;
	}
}
