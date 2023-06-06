using BehaviorTree;

public class CheckNeedFood : Node
{
    public CheckNeedFood(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = _root.FoodValue <= _root.WaterValue || _root.FoodValue < 50f ? NodeState.SUCCESS : NodeState.FAILURE;

        _root.NodeDebug = "Food";
        
        return _state;
    }
}