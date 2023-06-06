using BehaviorTree;
using UnityEngine;

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
        
        if(_root.Target != null && _root.Target.CompareTag("Target")) Object.Destroy(_root.Target.gameObject);

        _root.SetFood((Food)food);
        _root.SetTarget(food.Transform);
        
        _state = NodeState.SUCCESS;
        return _state;
    }
}