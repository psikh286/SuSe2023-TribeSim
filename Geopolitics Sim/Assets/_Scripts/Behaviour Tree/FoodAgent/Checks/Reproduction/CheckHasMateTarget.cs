using BehaviorTree;

public class CheckHasMateTarget : Node
{
    public CheckHasMateTarget(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = _root.Mate == null ? NodeState.FAILURE : NodeState.SUCCESS;
        
        return _state;
    }
}