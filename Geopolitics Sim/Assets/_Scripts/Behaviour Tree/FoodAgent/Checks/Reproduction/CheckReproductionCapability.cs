using BehaviorTree;

public class CheckReproductionCapability : Node
{
    public CheckReproductionCapability(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = (_root.FoodCount >= GlobalSettings.FoodToRep) && (_root.WaterCount >= GlobalSettings.WaterToRep)
            ? NodeState.SUCCESS
            : NodeState.FAILURE;
        
        return _state;
    }
}