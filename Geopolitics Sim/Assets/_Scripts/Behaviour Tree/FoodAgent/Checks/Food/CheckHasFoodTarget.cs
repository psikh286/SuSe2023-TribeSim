using BehaviorTree;

public class CheckHasFoodTarget : Node
{
    public CheckHasFoodTarget(FoodAgentTree root)
    {
        _root = root;
    }

    public override NodeState Evaluate()
    {
        _state = _root.Food == null ? NodeState.FAILURE : NodeState.SUCCESS;
            
        return _state;
    }
}