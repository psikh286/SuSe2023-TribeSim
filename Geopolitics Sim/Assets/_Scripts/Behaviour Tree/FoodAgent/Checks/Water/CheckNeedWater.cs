using BehaviorTree;

public class CheckNeedWater : Node
{
    public CheckNeedWater(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = _root.WaterCount < 2 ? NodeState.SUCCESS : NodeState.FAILURE;
        
        return _state;
    }
}