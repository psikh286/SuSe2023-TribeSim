using BehaviorTree;

public class CheckNoEnergy : Node
{
    public CheckNoEnergy(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = _root.EnergyLevel <= GlobalSettings.EnergyRestPoint ? NodeState.SUCCESS : NodeState.FAILURE;
        
        _root.NodeDebug = "CheckNoEnergy";
        
        return _state;
    }
}