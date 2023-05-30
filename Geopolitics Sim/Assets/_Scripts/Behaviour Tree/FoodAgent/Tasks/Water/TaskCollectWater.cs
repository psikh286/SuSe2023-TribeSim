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
        _root.IncreaseFoodCount();
        
        _root.Food = null;
        _root.Target = null;
        
        _state = NodeState.RUNNING;
        return _state;
    }
}