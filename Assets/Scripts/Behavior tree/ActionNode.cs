/* Acknowledge:
    The behavior tree section was modified from book:
    <Unity 2017 Game AI Programming - Third Edition>
            by Thet Naing Swe, Aung Sithu Kyaw, Ray Barrera   
    link: https://learning.oreilly.com/library/view/unity-2017-game/9781788477901/        
*/

// NOTE:
// ActionNode is for both action and condition tasks

using System;
using UnityEngine;
using System.Collections;

public class ActionNode : Node
{
    // assign a specific action and condition for this action
    public delegate NodeStates ReturnActionNode();

    private ReturnActionNode action;

    // actionNode consturctor
    public ActionNode(ReturnActionNode _action)
    {
        action = _action;
    }

    public override NodeStates Execute()
    {
        switch (action())
        {
            case NodeStates.SUCCESS:
                node_state = NodeStates.SUCCESS;
                return node_state;
            case NodeStates.FAIL:
                node_state = NodeStates.FAIL;
                return node_state;
            default:
                node_state = NodeStates.FAIL;
                return node_state;
        }

    }
}