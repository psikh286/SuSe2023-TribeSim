using BehaviorTree;

public class CheckHasWaterTarget : Node
{
    public CheckHasWaterTarget(FoodAgentTree root)
    {
        _root = root;
    }

    public override NodeState Evaluate()
    {
        _state = _root.Water == null ? NodeState.FAILURE : NodeState.SUCCESS;
            
        return _state;
    }
}