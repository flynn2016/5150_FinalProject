using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour {
    NavMeshAgent agent;
    public Transform anchor;
    public Transform[] slot = new Transform[2];

    private Vector3 curr_slot;
    private readonly float rotationSpeed = 5f;

    private FormationController formationController;
	// Use this for initialization
	void Start () {
        formationController = anchor.GetComponent<FormationController>();
        agent = this.GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        if (formationController.formation_flag == 1) {
            curr_slot= slot[0].position;
        }
        else if (formationController.formation_flag == 2) {
            curr_slot = slot[1].position;
        }

        if(formationController.formation_flag != 0)
        agent.SetDestination(curr_slot);

        if (Vector3.Distance(curr_slot, this.transform.position) < 10)
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
