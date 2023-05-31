using BehaviorTree;

public class TaskCollectFood : Node
{
    public TaskCollectFood(FoodAgentTree root)
    {
        _root = root;
    }

    public override NodeState Evaluate()
    {
        _root.Food.Collect();
        _root.IncreaseWaterCount();
        
        _root.SetFood(null);
        _root.SetTarget(null);
        
        _state = NodeState.RUNNING;
        return _state;
    }
}