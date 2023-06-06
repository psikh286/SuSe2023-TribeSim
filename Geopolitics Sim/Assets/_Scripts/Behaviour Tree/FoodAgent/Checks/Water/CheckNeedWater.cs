using BehaviorTree;

public class CheckNeedWater : Node
{
    public CheckNeedWater(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = _root.WaterValue < 20f ? NodeState.SUCCESS : NodeState.FAILURE;
        
        _root.NodeDebug = $"water  {_state}";
        
        return _state;
    }
}