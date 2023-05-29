using BehaviorTree;

public class CheckFoodInFOVRange : Node
{
    private readonly IFoodFinder _finder;
    
    public CheckFoodInFOVRange(FoodAgentTree root)
    {
        _root = root;
        _finder = root.GetComponent<IFoodFinder>();
    }
    
    public override NodeState Evaluate()
    {
        var f = _root.Food;
        if (f != null)
        {
            _state = NodeState.SUCCESS;
            return _state;
        }
        
        var food = _finder.FindFood();

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