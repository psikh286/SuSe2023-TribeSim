using BehaviorTree;

public class CheckHasFood : Node
{
    public CheckHasFood(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = _root.FoodValue > 0 ? NodeState.SUCCESS : NodeState.FAILURE;
        
        _root.NodeDebug = "CheckHasFood";

        
        return _state;
    }
}