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
        anchor = GameObject.Find("Anchor").transform;
        formationController = anchor.GetComponent<FormationController>();
        agent = this.GetComponent<NavMeshAgent>();
        index_troop = this.transform.GetSiblingIndex();
    }
	
	// Update is called once per frame
	void Update () {
        if (formationController.formation_flag == 1) {
            curr_slot = formationController.formation_1_slots[index_troop].position;
        }
        else if (formationController.formation_flag == 2) {
            curr_slot = formationController.formation_2_slots[index_troop].position;
        }

        if (formationController.formation_flag != 0)
        agent.SetDestination(curr_slot);

        if (Vector3.Distance(curr_slot, this.transform.position) < 15)
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
