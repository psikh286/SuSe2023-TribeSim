using BehaviorTree;

public class DebugNode : Node
{
    private readonly string _message;
    
    public DebugNode(FoodAgentTree root, string message)
    {
        _root = root;
        _message = message;
    }
    
    public override NodeState Evaluate()
    {
        _root.OnAgentAct?.Invoke(_message);

        _state = NodeState.SUCCESS;
        return _state;
    }
}