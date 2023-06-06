using BehaviorTree;

public class CheckIsThirsty : Node
{
    public CheckIsThirsty(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = _root.WaterRemaining <= GlobalSettings.IsThirstyThreshold ? NodeState.SUCCESS : NodeState.FAILURE;
        
        _root.NodeDebug = "CheckIsThirsty";

        
        return _state;
    }
}