using BehaviorTree;

public class TaskCollectWater : Node
{
    public TaskCollectWater(FoodAgentTree root)
    {
        _root = root;
    }

    public override NodeState Evaluate()
    {
        _root.RememberPosition("Water", _root.Water.transform.position);
        
        _root.Water.Collect();
        _root.IncreaseWaterCount(_root.Water.GetFoodRegain());
        
        _root.SetWater(null);
        _root.SetTarget(null);
        
        _root.NodeDebug = "TaskCollectWater";
        
        _root.SpendEnergy(EnergySettings.CollectWater);
        _root.SetCooldown(CooldownConfiguration.CollectWater);
        
        _state = NodeState.RUNNING;
        return _state;
    }
}