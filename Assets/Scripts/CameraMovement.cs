using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    private Camera cam;
    private bool dragging;
    Vector3 temp;
    [HideInInspector]
    public bool focusing;

    private void Start()
    {
        speed = 200f;
        cam = Camera.main;
        temp = this.transform.position;
    }

    private void Update()
    {
        //camera drag
        if (Input.GetMouseButton(0) && !focusing)
        {
            Vector3 temp_mos;
            temp_mos = transform.position;
            temp_mos -= Input.GetAxis("Mouse X") * speed * Time.deltaTime * transform.right;
            temp_mos -= Input.GetAxis("Mouse Y") * speed * Time.deltaTime * transform.up;
            transform.position = temp_mos;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && !focusing)
        {
            Camera.main.fieldOfView--;
            dragging = true;
        }
        else
            dragging = false;

        if (Input.GetAxis("Mouse ScrollWheel") < 0&& !focusing)
        {
            Camera.main.fieldOfView++;
            dragging = true;
        }
        else
            dragging = false;

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "myTroops"&&!focusing&&!dragging)
                {
                    focusing = true;
                    temp = this.transform.position;
                    transform.position=hit.transform.GetChild(0).transform.position;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            focusing = false;
            this.transform.position = temp;
        }
    }
}
	