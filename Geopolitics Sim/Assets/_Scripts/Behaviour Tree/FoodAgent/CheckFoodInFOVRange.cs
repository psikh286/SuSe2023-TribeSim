using BehaviorTree;
using UnityEngine;

public class CheckFoodInFOVRange : Node
{
    private readonly IFoodFinder _finder;
    
    public CheckFoodInFOVRange(BTree root)
    {
        _root = root;
        _finder = root.GetComponent<IFoodFinder>();
    }
    
    public override NodeState Evaluate()
    {
        var f = (Object)_root.GetData("food");
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

        _root.SetData("food", food);
        _root.SetData("target", food.Transform);
        _state = NodeState.SUCCESS;
        return _state;
    }
}