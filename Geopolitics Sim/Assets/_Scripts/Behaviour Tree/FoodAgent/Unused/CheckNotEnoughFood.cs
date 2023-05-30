using BehaviorTree;

public class CheckNotEnoughFood : Node
{
    public CheckNotEnoughFood(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = _root.FoodCount < GlobalSettings.FoodToRep ? NodeState.SUCCESS : NodeState.FAILURE;
        
        return _state;
    }
}