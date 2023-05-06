using BehaviorTree;

public class CheckNotEnoughFood : Node
{
    public CheckNotEnoughFood(BTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var foodCount = (int)_root.GetData("foodCount");
        
        _state = foodCount < GlobalSettings.FoodToRep ? NodeState.SUCCESS : NodeState.FAILURE;
        
        return _state;
    }
}