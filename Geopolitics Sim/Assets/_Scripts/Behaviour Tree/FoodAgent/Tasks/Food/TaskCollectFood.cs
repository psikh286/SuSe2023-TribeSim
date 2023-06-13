using BehaviorTree;

public class TaskCollectFood : Node
{
    public TaskCollectFood(FoodAgentTree root)
    {
        _root = root;
    }

    public override NodeState Evaluate()
    {
        _root.RememberPosition("Food", _root.Food.transform.position);
        
        _root.Food.Collect();
        _root.IncreaseFoodValue(_root.Food.GetFoodRegain());
        
        _root.SetFood(null);
        _root.SetTarget(null);
        
        _root.SpendEnergy(EnergySettings.CollectFood);
        _root.SetCooldown(CooldownConfiguration.CollectFood);
        
        _state = NodeState.RUNNING;
        return _state;
    }
}