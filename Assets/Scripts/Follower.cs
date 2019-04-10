using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour {
    NavMeshAgent agent;
    private Transform anchor;
    private Vector3 curr_slot;
    private readonly float rotationSpeed = 5f;
    private int index_troop;

    private FormationController formationController;
	// Use this for initialization
	void Start () {
        if (this.transform.parent.name == "myTroop_1")
        {
            anchor = GameObject.Find("Anchor_troop1").transform;
        }
        else if (this.transform.parent.name == "myTroop_2")
        {
            anchor = GameObject.Find("Anchor_troop2").transform;
        }
        else if (this.transform.parent.name == "myTroop_3")
        {
            anchor = GameObject.Find("Anchor_troop3").transform;
        }
        else if (this.transform.parent.name == "myTroop_4")
        {
            anchor = GameObject.Find("Anchor_troop4").transform;
        }
        else if (this.transform.parent.name == "myTroop_5")
        {
            anchor = GameObject.Find("Anchor_troop5").transform;
        }
        else if (this.transform.parent.name == "myTroop_6")
        {
            anchor = GameObject.Find("Anchor_troop6").transform;
        }
        else if (this.transform.parent.name == "myTroop_7")
        {
            anchor = GameObject.Find("Anchor_troop7").transform;
        }
        else if (this.transform.parent.name == "myTroop_8")
        {
            anchor = GameObject.Find("Anchor_troop8").transform;
        }
        formationController = anchor.GetComponent<FormationController>();
        agent = this.GetComponent<NavMeshAgent>();
        index_troop = this.transform.GetSiblingIndex();
    }
	
	// Update is called once per frame
	void Update () {
        if (formationController.leader.formation_flag == 1) {
            curr_slot = formationController.formation_1_slots[index_troop].position;
        }
        else if (formationController.leader.formation_flag == 2) {
            curr_slot = formationController.formation_2_slots[index_troop].position;
        }

        if (formationController.leader.formation_flag != 0)
        {
            agent.SetDestination(curr_slot);
        }

        if (Vector3.Distance(curr_slot, this.transform.position) < 25)
        {
            RotateTowards();
        }
    }

    private void RotateTowards()
    {
        Vector3 direction = new Vector3(formationController.facing_dir.x,0,formationController.facing_dir.y);
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
