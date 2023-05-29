using BehaviorTree;
using UnityEngine;

public class CheckFoodInEatingRange : Node
{
    public CheckFoodInEatingRange(FoodAgentTree root)
    {
        _root = root;
    }

    public override NodeState Evaluate()
    {
        var food = _root.Food;
        var target = _root.Target;
        
        if (food == null || target == null)
        {
            _state = NodeState.FAILURE;
            _root.Food = null;
            return _state;
        }

        _state = Vector3.Distance(_root.transform.position, target.position) > 0.01f ? NodeState.FAILURE : NodeState.SUCCESS;

        return _state;
    }
}