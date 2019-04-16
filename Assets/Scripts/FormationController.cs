using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class FormationController : MonoBehaviour {

    [HideInInspector]
    public Vector2 facing_dir;


    public Transform formation_1;
    public Transform formation_2;
    public Transform myTroop;
    public GameObject Footman_prefab;
    public Transform spawnLocation;
    public Leader leader;

    private Camera cam;
    NavMeshAgent agent;
    public int troop_size;
    private int max_troop = 10;
    private Vector3 curr_slot;
    private int index_troop;
    [HideInInspector]
    public Transform[] formation_1_slots;
    [HideInInspector]
    public Transform[] formation_2_slots; 

    public Transform army_anchors;
    // Use this for initialization
    void Start () {
    formation_1_slots = new Transform[max_troop];
    formation_2_slots = new Transform[max_troop];
    cam = Camera.main;
        agent = this.GetComponent<NavMeshAgent>();

        troop_size = 10;
        for(int i=0; i < max_troop; i++)
        {
            formation_1_slots[i] = formation_1.GetChild(i);
            formation_2_slots[i] = formation_2.GetChild(i);
        }
        index_troop = this.transform.GetSiblingIndex();

    }
	
	// Update is called once per frame
	void Update () {
        facing_dir = new Vector2(-formation_1.position.x + formation_1.GetChild(0).position.x, -formation_1.position.z + formation_1.GetChild(0).position.z);
        if (leader.formation_flag == 1)
        {
            curr_slot = leader.leader_slots_1[index_troop].position;
        }
        else if (leader.formation_flag == 2)
        {
            curr_slot = leader.leader_slots_2[index_troop].position;
        }

        else if (leader.formation_flag == 3)
        {
            curr_slot = leader.leader_slots_3[index_troop].position;
        }
        else if (leader.formation_flag == 4)
        {
            curr_slot = leader.leader_slots_4[index_troop].position;
        }


        agent.SetDestination(curr_slot);

        if (Vector3.Distance(curr_slot, this.transform.position) < 25)
        {
            RotateTowards();
        }
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


    private void RotateTowards()
    {
        Vector3 direction = new Vector3(leader.facing_dir.x, 0, leader.facing_dir.y);
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }
}
