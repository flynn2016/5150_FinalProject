using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Leader : MonoBehaviour {
    [HideInInspector]
    public Vector2 facing_dir;
    [HideInInspector]
    public int formation_flag = 0;

    private Camera cam;
    NavMeshAgent agent;

    public Transform leader_formation_1;
    public Transform leader_formation_2;

    [HideInInspector]
    public Transform[] leader_slots_1;
    [HideInInspector]
    public Transform[] leader_slots_2;

    private int max_leader = 8;

    // Use this for initialization
    void Start () {
        cam = Camera.main;
        agent = this.GetComponent<NavMeshAgent>();
        leader_slots_1 = new Transform[max_leader];
        leader_slots_2 = new Transform[max_leader];
        if (this.name == "Enemy_Leader_anchors")
            facing_dir = new Vector2(-1, 0);
        else
            facing_dir = new Vector2(1, 0);
        for (int i = 0; i < max_leader; i++)
        {
            leader_slots_1[i] = leader_formation_1.GetChild(i);
            leader_slots_2[i] = leader_formation_2.GetChild(i);
        }
        formation_flag = 1;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)&&Input.GetAxis("Mouse X")==0)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    //agent.SetDestination(hit.point);
                    //facing_dir = new Vector2((hit.point.x - transform.position.x), (hit.point.z - transform.position.z)).normalized;
                }
            }
        }
    }

    public void Set_formation(int index)
    {
        formation_flag = index;
    }

    public void StartWar()
    {
        if(this.name== "Leader_anchors")
            agent.SetDestination(new Vector3 (300,0,0));
        else
            agent.SetDestination(new Vector3(-300, 0, 0));
    }
}
