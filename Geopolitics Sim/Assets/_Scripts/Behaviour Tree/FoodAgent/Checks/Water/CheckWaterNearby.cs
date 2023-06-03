using BehaviorTree;

public class CheckWaterNearby : Node
{
    private readonly IFoodFinder _finder;
    
    public CheckWaterNearby(FoodAgentTree root)
    {
        _root = root;
        _finder = root.GetComponent<IFoodFinder>();
    }
    
    public override NodeState Evaluate()
    {
        var water = _finder.FindFood(typeof(Water));

        if (water == null)
        {
            _state = NodeState.FAILURE;
            return _state;
        }

        _root.SetWater((Water)water);
        _root.SetTarget(water.Transform);
        
        _state = NodeState.SUCCESS;
        return _state;
    }
}