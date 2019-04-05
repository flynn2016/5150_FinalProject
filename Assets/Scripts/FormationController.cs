using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class FormationController : MonoBehaviour {
    [HideInInspector]
    public int formation_flag = 0;
    [HideInInspector]
    public Vector2 facing_dir;
    public Transform leader;

    private Camera cam;
    NavMeshAgent agent;
    private int troop_size;
    private Vector3[] slots = new Vector3[20];
	// Use this for initialization
	void Start () {
        cam = Camera.main;
        agent = this.GetComponent<NavMeshAgent>();
        facing_dir = new Vector2(1,0);
        troop_size = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    agent.SetDestination(hit.point);
                    facing_dir = new Vector2((hit.point.x - transform.position.x), (hit.point.z - transform.position.z)).normalized;
                }
            }
        }
    }

    public void Set_formation(int index)
    {
        formation_flag = index;
    }
}
