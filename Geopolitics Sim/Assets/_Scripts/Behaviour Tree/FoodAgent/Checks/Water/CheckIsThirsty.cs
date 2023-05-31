using BehaviorTree;

public class CheckIsThirsty : Node
{
    public CheckIsThirsty(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = _root.WaterRemaining <= GlobalSettings.IsThirstyPercent ? NodeState.SUCCESS : NodeState.FAILURE;
        
        return _state;
    }
}