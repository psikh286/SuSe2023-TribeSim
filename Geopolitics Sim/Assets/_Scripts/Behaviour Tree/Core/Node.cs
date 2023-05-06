
namespace BehaviorTree
{
    public abstract class Node
    {
        protected NodeState _state;
        protected BTree _root;

        public abstract NodeState Evaluate();
    }
}

