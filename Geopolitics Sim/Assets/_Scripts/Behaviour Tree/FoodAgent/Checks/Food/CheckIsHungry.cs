using BehaviorTree;

public class CheckIsHungry : Node
{
    public CheckIsHungry(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = _root.HungerRemaining <= GlobalSettings.IsHungryPercent ? NodeState.SUCCESS : NodeState.FAILURE;
        
        return _state;
    }
}