using BehaviorTree;

public class CheckReproductionCapability : Node
{
    public CheckReproductionCapability(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = (_root.FoodValue >= GlobalSettings.FoodToRep) && (_root.WaterValue >= GlobalSettings.WaterToRep) && (_root.ReproductionCooldown <= 0)
            ? NodeState.SUCCESS
            : NodeState.FAILURE;

        _root.NodeDebug = "REPROD";
        return _state;
    }
}