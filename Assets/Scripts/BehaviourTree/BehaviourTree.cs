using System.Collections.Generic;
using UnityEngine;

namespace zhk.BehaviourTree
{
    public enum NodeState
    {
        SUCCESS,
        RUNNING,
        FAILURE
    }
    public class Node
    {
        public int childIndex;
        public List<Node> childrenNodes = new List<Node>(0);

        public void AttachNode(Node node)
        {
            childrenNodes.Add(node);
        }

        public virtual NodeState Execute()
        {
            return NodeState.FAILURE;
        }

        public void ResetNode()
        {
            childIndex = 0;
            foreach (Node child in childrenNodes) {
                child.ResetNode();
            }
        }
    }
    public class SequenceNode : Node
    {
        public SequenceNode(int childAmount)
        {
            childIndex = 0;
            childrenNodes = new List<Node>(childAmount);
        }

        public override NodeState Execute()
        {
            NodeState state = childrenNodes[childIndex].Execute();

            if (state == NodeState.FAILURE)
            {
                ResetNode();
                return state;
            }

            if (childIndex >= childrenNodes.Count - 1 && state == NodeState.SUCCESS)
            {
                ResetNode();
                return state;
            }

            if (state == NodeState.SUCCESS)
            {
                childIndex++;
            }
            return NodeState.RUNNING;
        }
    }
}

