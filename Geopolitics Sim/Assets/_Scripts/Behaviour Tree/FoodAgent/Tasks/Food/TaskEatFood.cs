using BehaviorTree;

public class TaskEatFood : Node
{
    public TaskEatFood(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _root.EatFood();
        
        _root.NodeDebug = "TaskEatFood";
        _root.OnAgentAct?.Invoke("Eating Food");
        
        _root.SpendEnergy(EnergySettings.EatFood);
        _root.SetCooldown(CooldownConfiguration.EatFood);

        _state = NodeState.RUNNING;
        return _state;
    }
}