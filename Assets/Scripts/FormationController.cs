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
    public Transform formation_1;
    public Transform formation_2;
    public Transform myTroop;
    public GameObject Footman_prefab;
    public Transform spawnLocation;

    private Camera cam;
    NavMeshAgent agent;
    private int troop_size;
    private int max_troop = 10;
    [HideInInspector]
    public Transform[] formation_1_slots;
    [HideInInspector]
    public Transform[] formation_2_slots; 
    // Use this for initialization
    void Start () {
    formation_1_slots = new Transform[max_troop];
    formation_2_slots = new Transform[max_troop];
    cam = Camera.main;
        agent = this.GetComponent<NavMeshAgent>();
        facing_dir = new Vector2(1,0);
        troop_size = 10;
        for(int i=0; i < 10; i++)
        {
            Debug.Log(i);
            formation_1_slots[i] = formation_1.GetChild(i);
            formation_2_slots[i] = formation_2.GetChild(i);
        }
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

    public void Remove_footman() {
        if (myTroop.childCount > 0)
        {
            GameObject.Destroy(myTroop.GetChild(myTroop.childCount - 1).gameObject);
        }
    }

    public void Add_footman()
    {
        if (myTroop.childCount < max_troop)
        {
            Follower temp=GameObject.Instantiate(Footman_prefab, spawnLocation.position, Quaternion.identity, myTroop).GetComponent<Follower>();
        }
    }
}
