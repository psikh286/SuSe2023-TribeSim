using BehaviorTree;

public class CheckNeedFood : Node
{
    public CheckNeedFood(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = _root.FoodCount < 2 ? NodeState.SUCCESS : NodeState.FAILURE;
        
        return _state;
    }
}