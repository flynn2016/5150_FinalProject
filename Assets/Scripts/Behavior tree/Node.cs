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