
namespace BehaviorTree
{
    public abstract class Node
    {
        protected NodeState _state;
        protected FoodAgentTree _root;

        public abstract NodeState Evaluate();
    }
}

