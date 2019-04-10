using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public float speed;

    private void Start()
    {
        speed = 200f;
    }

    private void Update()
    {
        //camera drag
        if (Input.GetMouseButton(0))
        {
            Vector3 temp;
            temp = transform.position;
            temp -= Input.GetAxis("Mouse X") * speed * Time.deltaTime * transform.right;
            temp -= Input.GetAxis("Mouse Y") * speed * Time.deltaTime * transform.up;
            transform.position = temp;
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.fieldOfView--;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Camera.main.fieldOfView++;
        }
    }
}
	