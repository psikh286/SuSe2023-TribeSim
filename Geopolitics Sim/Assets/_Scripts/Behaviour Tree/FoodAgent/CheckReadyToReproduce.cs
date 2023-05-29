using BehaviorTree;

public class CheckReadyToReproduce : Node
{
    public CheckReadyToReproduce(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var mate = _root.Mate;
        if (mate != null)
        {
            _state = NodeState.SUCCESS;
            return _state;
        }

        _state = _root.FoodCount >= GlobalSettings.FoodToRep ? NodeState.SUCCESS : NodeState.FAILURE;
        return _state;
    }
}