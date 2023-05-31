using BehaviorTree;

public class TaskCollectWater : Node
{
    public TaskCollectWater(FoodAgentTree root)
    {
        _root = root;
    }

    public override NodeState Evaluate()
    {
        _root.Water.Collect();
        _root.IncreaseWaterCount();
        
        _root.SetWater(null);
        _root.SetTarget(null);
        
        _state = NodeState.RUNNING;
        return _state;
    }
}