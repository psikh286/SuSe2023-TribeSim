using System.Collections.Generic;

namespace BehaviorTree
{
    public class Sequence : Node
    {
        protected readonly List<Node> _children;
        
        public Sequence(BTree root, List<Node> children)
        {
            _children = children;
            _root = root;
        }

        /* If any child node returns a failure, the entire node fails. Whence all  
           nodes return a success, the node reports a success. */ 
        public override NodeState Evaluate()
        {
            var anyChildIsRunning = false;

            foreach (var node in _children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        _state = NodeState.FAILURE;
                        return _state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        anyChildIsRunning = true;
                        continue;
                    default:
                        _state = NodeState.SUCCESS;
                        return _state;
                }
            }

            _state = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return _state;
        }
    }

}