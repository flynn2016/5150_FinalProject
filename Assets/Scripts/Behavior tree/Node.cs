/* Acknowledge:
    The behavior tree section was modified from book:
    <Unity 2017 Game AI Programming - Third Edition>
            by Thet Naing Swe, Aung Sithu Kyaw, Ray Barrera   
    link: https://learning.oreilly.com/library/view/unity-2017-game/9781788477901/        
*/

using UnityEngine;
using System.Collections;

// we might use RUNNING state
public enum NodeStates {FAIL, SUCCESS};

[System.Serializable]
public abstract class Node
{

    public delegate NodeStates ReturnNodeState();

    protected NodeStates node_state;

    public NodeStates nodeState
    {
        get { return node_state; }
    }

    public abstract NodeStates Execute();

}