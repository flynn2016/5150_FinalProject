
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : MonoBehaviour
{
    public Selector root_node;
    public ActionNode sample_action;
    
    // Start is called before the first frame update
    void Start()
    {
        // list of action that in the root node.
        List<Node> root_node_list = new List<Node>();
        sample_action = new ActionNode(DebugMessage);

        root_node_list.Add(sample_action);

        root_node = new Selector(root_node_list);
    }

    // TODO:
    // Action and condtion nodes go here

    NodeStates DebugMessage()
    {
        Debug.Log("Move");
        return NodeStates.SUCCESS;
    }
}
