using BehaviorTree;
using UnityEngine;

public class TaskEatFood : Node
{
    public TaskEatFood(BTree root)
    {
        _root = root;
    }

    public override NodeState Evaluate()
    {
        var food = (IFood)_root.GetData("food");
        var foodCount = (int)_root.GetData("foodCount");
        
        food.EatFood();
        
        _root.SetData("foodCount", foodCount + 1);
        _root.ClearData("food");
        _root.ClearData("target");
        
        _state = NodeState.RUNNING;
        return _state;
    }
}