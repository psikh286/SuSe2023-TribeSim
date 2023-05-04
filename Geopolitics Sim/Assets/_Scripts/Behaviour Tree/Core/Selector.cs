﻿using System.Collections.Generic;

namespace BehaviorTree
{
    public class Selector : Node
    {
        public Selector() { }
        public Selector(List<Node> children) : base(children) { }

        /* If any of the children reports a success, the selector will 
           immediately report a success upwards. If all children fail, 
           it will report a failure instead.*/
        public override NodeState Evaluate()
        {
            foreach (var node in _children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        _state = NodeState.SUCCESS;
                        return _state;
                    case NodeState.RUNNING:
                        _state = NodeState.RUNNING;
                        return _state;
                    default:
                        continue;
                }
            }

            _state = NodeState.FAILURE;
            return _state;
        }

    }

}