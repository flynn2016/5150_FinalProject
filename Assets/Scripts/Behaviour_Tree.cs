using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour_Tree {
    Hashtable lookup = new Hashtable();
    const int SUCCESS = 1;
    const int FAIL = 0;

    abstract class Task
    {
        public abstract int Execute();

    }

    class Selector : Task
    {
        List<Task> m_tasks = new List<Task>();
        public Selector(List<Task> tasks)
        {
            m_tasks = tasks;
        }

        override public int Execute()
        {
            foreach(Task task in m_tasks)
            {
                if (task.Execute() == SUCCESS)
                {
                    return SUCCESS;
                }
            }
            return FAIL;
        }
    }
}


