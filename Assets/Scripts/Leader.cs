﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Leader : MonoBehaviour {

    private Camera cam;
    NavMeshAgent agent;
    public Transform anchor;
    [HideInInspector]
    public Vector3 dest;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        agent = this.GetComponent<NavMeshAgent>();
        dest = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                dest = hit.point ;
                Vector2 formation_dir = new Vector2(dest.x - anchor.position.x, dest.z - anchor.position.z);
                Vector3 formation_pos = new Vector3(this.transform.position.x+formation_dir.normalized.x * 50, 15, this.transform.position.z + formation_dir.normalized.y*50);
                Debug.Log(formation_dir.normalized);
                agent.SetDestination(formation_pos);
            }


        }
    }

    public void Move(Vector3 dest)
    {
        if(agent!=null)
        agent.SetDestination(dest);
    }
}