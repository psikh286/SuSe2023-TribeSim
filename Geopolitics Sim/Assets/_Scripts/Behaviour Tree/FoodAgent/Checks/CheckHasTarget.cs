using BehaviorTree;

public class CheckHasTarget : Node
{
    public CheckHasTarget(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = _root.Target == null ? NodeState.FAILURE : NodeState.SUCCESS;
        
        return _state;
    }
}