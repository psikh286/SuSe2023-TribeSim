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
        
        _state = NodeState.RUNNING;
        return _state;
    }
}