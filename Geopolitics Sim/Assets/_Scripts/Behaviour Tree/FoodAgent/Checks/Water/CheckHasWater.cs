using BehaviorTree;

public class CheckHasWater : Node
{
    public CheckHasWater(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = _root.WaterValue > 0 ? NodeState.SUCCESS : NodeState.FAILURE;
        
        _root.NodeDebug = "CheckHasWater";

        
        return _state;
    }
}