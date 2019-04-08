/* Acknowledge:
    The behavior tree section was modified from book:
    <Unity 2017 Game AI Programming - Third Edition>
            by Thet Naing Swe, Aung Sithu Kyaw, Ray Barrera   
    link: https://learning.oreilly.com/library/view/unity-2017-game/9781788477901/        
*/


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
                    continue;
                default:
                    node_state = NodeStates.SUCCESS;
                    return node_state;
            }
        }
        return node_state;
    }
}
