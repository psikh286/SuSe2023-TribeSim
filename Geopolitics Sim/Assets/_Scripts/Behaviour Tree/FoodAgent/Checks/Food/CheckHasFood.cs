using BehaviorTree;

public class CheckHasFood : Node
{
    public CheckHasFood(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = _root.FoodCount > 0 ? NodeState.SUCCESS : NodeState.FAILURE;
        
        return _state;
    }
}