
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : MonoBehaviour
{
    public Selector root_node;
    public Sequencer sequencer_1;
    public Sequencer sequencer_2;
    public ActionNode follow;
    public ActionNode detecting_enemy;
    public ActionNode attack;

    public ActionNode detecting_area;
    public ActionNode is_occupied;
    public ActionNode move;

    private Transform[] footman;
    private AdvantagePoint zone_red;
    private AdvantagePoint zone_blue;

    void Start()
    {
        zone_blue = GameObject.Find("Zone_blue").GetComponent<AdvantagePoint>();
        zone_red = GameObject.Find("Zone_red").GetComponent<AdvantagePoint>();
        footman = new Transform[7];
        for(int i = 0; i < 7; i++)
        {
            footman[i] = this.transform.GetChild(i);
        }
        // list of action that in the root node.
        List<Node> root_node_list = new List<Node>();
        List<Node> sequencer1_node_list = new List<Node>();
        List<Node> sequencer2_node_list = new List<Node>();

        attack = new ActionNode(Attack);
        follow = new ActionNode(Follow);
        detecting_enemy = new ActionNode(EnemyInSight);

        detecting_area = new ActionNode(AreaInSight);
        is_occupied = new ActionNode(Checking_occupy);
        move = new ActionNode(Move);

        sequencer1_node_list.Add(detecting_enemy);
        sequencer1_node_list.Add(attack);
        sequencer2_node_list.Add(detecting_area);
        sequencer2_node_list.Add(is_occupied);
        sequencer2_node_list.Add(move);

        sequencer_1 = new Sequencer(sequencer1_node_list);
        sequencer_2 = new Sequencer(sequencer2_node_list);

        root_node_list.Add(sequencer_2);
        root_node_list.Add(sequencer_1);
        root_node_list.Add(follow);

        root_node = new Selector(root_node_list);
    }

    void FixedUpdate()
    {
        root_node.Execute();
    }
    // TODO:
    // Action and condtion nodes go here

    NodeStates Follow()
    {
        for (int i = 0; i < 7; i++)
        {
            if(footman[i].gameObject.activeSelf==true)
            footman[i].GetComponent<Follower>().Go2Anchor();
        }
       
        return NodeStates.SUCCESS;
    }

    NodeStates EnemyInSight()
    {
        for (int i = 0; i < 7; i++)
        {
            if (footman[i].gameObject.activeSelf == true)
            {
                if (footman[i].GetComponent<Follower>().EnemyInSight())
                {
                    return NodeStates.SUCCESS;

                }
            }
        }
        return NodeStates.FAIL;
    }

    NodeStates Attack()
    {
        for (int i = 0; i < 7; i++)
        {
            if (footman[i].gameObject.activeSelf == true)
                footman[i].GetComponent<Follower>().AttackClosestEnemy();
        }
        return NodeStates.SUCCESS;
    }

    NodeStates AreaInSight()
    {
        for (int i = 0; i < 7; i++)
        {
            if (footman[i].gameObject.activeSelf == true)
            {
                if (footman[i].GetComponent<Follower>().AreaInSight())
                {
                    return NodeStates.SUCCESS;
                }
            }
        }
        return NodeStates.FAIL;
    }

    NodeStates Move()
    {
        for (int i = 0; i < 7; i++)
        {
            if (footman[i].gameObject.activeSelf == true)
                footman[i].GetComponent<Follower>().Move_to_area();
        }
        return NodeStates.SUCCESS;
    }

    NodeStates Checking_occupy()
    {
        for (int i = 0; i < 7; i++)
        {
            if (footman[i].gameObject.activeSelf == true)
            {
                if (footman[i].GetComponent<Follower>().Check_occupy())
                {
                    return NodeStates.SUCCESS;
                }
                else
                    return NodeStates.FAIL;
            }
        }
        return NodeStates.FAIL;
    }
}
