using BehaviorTree;

public class TaskRequestMate : Node
{
    public TaskRequestMate(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var accepted = _root.Mate.RequestMate(_root);

        if (!accepted)
        {
            _root.SetMate(null);
            _root.SetTarget(null);
        }
        
        _state = NodeState.RUNNING;
        return _state;
    }
}