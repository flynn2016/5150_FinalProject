﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Selector : Node
{
    protected List<Node> agent_nodes = new List<Node>();

    public Selector(List<Node> nodes)
    {
        agent_nodes = nodes;
    }

    public override NodeStates Execute()
    {
        foreach (Node node in agent_nodes)
        {
            switch (node.Execute())
            {
                case NodeStates.FAIL:
                    continue;
                case NodeStates.SUCCESS:
                    node_state = NodeStates.SUCCESS;
                    return nodeState;
                default:
                    continue;
            }
        }
        node_state = NodeStates.FAIL;
        return node_state;
    }
}