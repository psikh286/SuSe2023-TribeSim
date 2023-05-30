using BehaviorTree;

public class CheckFoodNearby : Node
{
    private readonly IFoodFinder _finder;
    
    public CheckFoodNearby(FoodAgentTree root)
    {
        _root = root;
        _finder = root.GetComponent<IFoodFinder>();
    }
    
    public override NodeState Evaluate()
    {
        var food = _finder.FindFood(typeof(Food));

        if (food == null)
        {
            _state = NodeState.FAILURE;
            return _state;
        }

        _root.Food = (Food)food;
        _root.Target = food.Transform;
        
        _state = NodeState.SUCCESS;
        return _state;
    }
}