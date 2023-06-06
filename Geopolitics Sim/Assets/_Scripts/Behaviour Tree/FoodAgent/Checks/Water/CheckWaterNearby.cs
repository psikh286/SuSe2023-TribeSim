using BehaviorTree;
using UnityEngine;

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
        
        if(_root.Target != null && _root.Target.CompareTag("Target")) Object.Destroy(_root.Target.gameObject);

        _root.SetWater((Water)water);
        _root.SetTarget(water.Transform);
        
        _state = NodeState.SUCCESS;
        return _state;
    }
}