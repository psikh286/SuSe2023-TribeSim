using BehaviorTree;

public class TaskWaitMate : Node
{
    public TaskWaitMate(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var mate = _root.Mate;
        
        if (mate == null)
        {
            _state = NodeState.FAILURE;
            return _state;
        }
        
        _state = _root != mate ? NodeState.FAILURE : NodeState.SUCCESS;

        return _state;
    }
}