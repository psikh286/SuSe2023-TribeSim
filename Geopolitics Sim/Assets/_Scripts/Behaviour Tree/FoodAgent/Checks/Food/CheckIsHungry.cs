using BehaviorTree;

public class CheckIsHungry : Node
{
    public CheckIsHungry(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = _root.HungerRemaining <= GlobalSettings.IsHungryThreshold ? NodeState.SUCCESS : NodeState.FAILURE;

        _root.NodeDebug = "CheckKIsHungry";
        
        return _state;
    }
}