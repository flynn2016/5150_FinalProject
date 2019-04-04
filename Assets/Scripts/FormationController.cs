using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour {
    public GameObject footman;
    private Vector3 spawnLocation;
    private Leader[] troop_footman = new Leader[10];
    private Vector3 anchor_point;
    private int size_footman;
	// Use this for initialization
	void Start () {
        anchor_point = this.transform.position;
        troop_footman[0] = GameObject.Find("mFootman").GetComponent<Leader>();
        size_footman = 1;
        spawnLocation = new Vector3(this.transform.position.x-100, this.transform.position.y, this.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        if (size_footman == 2)
        {
            Vector3 dest_1 = new Vector3(anchor_point.x, anchor_point.y, anchor_point.z + 100);
            Vector3 dest_2 = new Vector3(anchor_point.x, anchor_point.y, anchor_point.z - 100);
            troop_footman[0].Move(dest_1);
            troop_footman[1].Move(anchor_point);
        }
	}

    public void AddFootman()
    {
        GameObject curr_footman = Instantiate(footman, spawnLocation, Quaternion.Euler(0, 90, 0));
        curr_footman.transform.parent= this.transform;
        troop_footman[1] = curr_footman.GetComponent<Leader>();
        size_footman++;
    }
}
