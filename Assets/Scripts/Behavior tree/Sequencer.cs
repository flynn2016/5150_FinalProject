using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sequencer : Node
{
    private List<Node> agent_nodes = new List<Node>();

    public Sequencer(List<Node> nodes)
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
                    node_state = NodeStates.FAIL;
                    return node_state;
                case NodeStates.SUCCESS:
                    node_state = NodeStates.SUCCESS;
                    continue;
                default:
                    node_state = NodeStates.SUCCESS;
                    return node_state;
            }
        }
        return node_state;
    }
}
