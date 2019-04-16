using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour {
    private Transform zone_red;
    private Transform zone_blue;
    private Transform closest_zone;
    NavMeshAgent agent;
    private Transform anchor;
    private Vector3 curr_slot;
    private readonly float rotationSpeed = 5f;
    private int index_troop;

    private FormationController formationController;
    public Transform Army_anchors;
    private float health;
    private bool attacking;
    //attack
    private Transform target;
    private Transform temp;
    private float detect_radius;
    private int alley_nearby;

    // Use this for initialization
    void Start () {
        if (this.transform.parent.name == "myTroop_1")
        {
            anchor = Army_anchors.GetChild(0);
        }
        else if (this.transform.parent.name == "myTroop_2")
        {
            anchor = Army_anchors.GetChild(1);
        }
        else if (this.transform.parent.name == "myTroop_3")
        {
            anchor = Army_anchors.GetChild(2);
        }
        else if (this.transform.parent.name == "myTroop_4")
        {
            anchor = Army_anchors.GetChild(3);
        }
        else if (this.transform.parent.name == "myTroop_5")
        {
            anchor = Army_anchors.GetChild(4);
        }
        else if (this.transform.parent.name == "myTroop_6")
        {
            anchor = Army_anchors.GetChild(5);
        }
        else if (this.transform.parent.name == "myTroop_7")
        {
            anchor = Army_anchors.GetChild(6);
        }
        else if (this.transform.parent.name == "myTroop_8")
        {
            anchor = Army_anchors.GetChild(7);
        }
        zone_blue = GameObject.Find("Zone_blue").transform;
        zone_red = GameObject.Find("Zone_red").transform;
        formationController = anchor.GetComponent<FormationController>();
        agent = this.GetComponent<NavMeshAgent>();
        index_troop = this.transform.GetSiblingIndex();
        health = 200;
        detect_radius = 20;
    }
	
	// Update is called once per frame
	void Update () {

        if (health < 0)
        {
            this.gameObject.SetActive(false);
        }

        if (formationController.leader.formation_flag == 1) {
            if(formationController.leader.subform_flag == 1)
                curr_slot = formationController.formation_1_slots[index_troop].position;
            else
                curr_slot = formationController.formation_2_slots[index_troop].position;
        }
        else if (formationController.leader.formation_flag == 2) {
            if (formationController.leader.subform_flag == 1)
                curr_slot = formationController.formation_1_slots[index_troop].position;
            else
                curr_slot = formationController.formation_2_slots[index_troop].position;
        }
        else if (formationController.leader.formation_flag == 3)
        {
            if (formationController.leader.subform_flag == 1)
                curr_slot = formationController.formation_1_slots[index_troop].position;
            else
                curr_slot = formationController.formation_2_slots[index_troop].position;
        }
        else if (formationController.leader.formation_flag == 4)
        {
            if (formationController.leader.subform_flag == 1)
                curr_slot = formationController.formation_1_slots[index_troop].position;
            else
                curr_slot = formationController.formation_2_slots[index_troop].position;
        }

        if (Vector3.Distance(curr_slot, this.transform.position) < 25)
        {
            RotateTowards();
        }

        TakeDmg();
    }

    private void TakeDmg()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 20);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (this.tag == "Mine")
            {
                if (hitColliders[i].tag == "Enemy")
                {
                    if (zone_red.GetComponent<AdvantagePoint>().zone_control == 1)
                        health += 0.5f;
                    if(zone_blue.GetComponent<AdvantagePoint>().zone_control == 1)
                        health += 0.5f;
                    health -=5;
                    health += alley_nearby * 0.1f;
                }
            }

            else if (this.tag == "Enemy")
            {
                if (hitColliders[i].tag == "Mine")
                {
                    if (zone_red.GetComponent<AdvantagePoint>().zone_control == 2)
                        health += 0.5f;
                    if (zone_blue.GetComponent<AdvantagePoint>().zone_control == 2)
                        health += 0.5f;
                    health -=5;
                    health += alley_nearby * 0.1f;
                }
            }
        }
    }

    private void RotateTowards()
    {
        Vector3 direction = new Vector3(formationController.facing_dir.x,0,formationController.facing_dir.y);
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    public void Go2Anchor()
    {
        this.GetComponent<Animator>().SetBool("attacking", false);
        if (formationController.leader.formation_flag != 0)
        {
            agent.SetDestination(curr_slot);
        }
    }

    public bool EnemyInSight()
    {
        int temp_count = 0;
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, detect_radius);
        
        for(int i = 0; i < hitColliders.Length; i++)
        {
            if (this.tag == "Mine")
            {
                if (hitColliders[i].tag == "Enemy")
                {
                    target = hitColliders[i].transform;
                    return true;
                }

                else if(hitColliders[i].tag == "Mine")
                {
                    temp_count++;
                }
            }

            else if (this.tag == "Enemy")
            {
                if (hitColliders[i].tag == "Mine")
                {
                    target = hitColliders[i].transform;
                    return true;
                }
                else if (hitColliders[i].tag == "Enemy")
                {
                    temp_count++;
                }
            }
        }
        alley_nearby = temp_count;
        return false;
    }

    public bool AreaInSight()
    {
        if (Vector3.Distance(this.transform.position, zone_blue.position) < 100 )
        {
            closest_zone = zone_blue;
            return true;
        }   
        else if(Vector3.Distance(this.transform.position, zone_red.position) < 100)
        {
            closest_zone = zone_red;
            return true;
        }
        else
            return false;
    }

    public void AttackClosestEnemy()
    {
        this.GetComponent<Animator>().SetBool("attacking", true);
        if (target != null)
        {
            agent.SetDestination(target.position);         
        }
       detect_radius = 50;
    }

    public void Move_to_area()
    {
        if(closest_zone!=null)
        {
            agent.SetDestination(closest_zone.position);
        }
    }

    public bool Check_occupy()
    {
        if (this.tag == "Mine")
        {
            if (closest_zone != null)
            {
                if (closest_zone.GetComponent<AdvantagePoint>().zone_control != 1)
                    return true;
                else
                    return false;
            }
        }

        if (this.tag == "Enemy")
        {
            if (closest_zone != null)
            {
                if (closest_zone.GetComponent<AdvantagePoint>().zone_control != 2)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }
}
