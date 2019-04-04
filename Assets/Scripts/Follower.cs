using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    private Camera cam;
    NavMeshAgent agent;
    public Leader leader;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

            Debug.Log(leader.dest);
            agent.SetDestination(GetFourthPoint(leader.transform.position, leader.dest, this.transform.position));
    }

    Vector3 GetFourthPoint(Vector3 a, Vector3 b, Vector3 x)
    {
        Vector3 temp = new Vector3(x.x+b.x-a.x,5,x.z+b.z-a.z);

        return temp;
    }

}
