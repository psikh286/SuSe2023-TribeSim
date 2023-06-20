using BehaviorTree;

public class TaskDrinkWater : Node
{
    public TaskDrinkWater(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _root.DrinkWater();
        
        _root.NodeDebug = "TaskDrinkWater";
        _root.OnAgentAct?.Invoke("Drinking Food");
        
        _root.SpendEnergy(EnergySettings.DrinkWater);
        _root.SetCooldown(CooldownConfiguration.DrinkWater);
        
        _state = NodeState.RUNNING;
        return _state;
    }
}