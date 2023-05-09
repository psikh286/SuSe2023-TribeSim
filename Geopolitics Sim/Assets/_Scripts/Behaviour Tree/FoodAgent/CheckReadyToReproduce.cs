using BehaviorTree;
using UnityEngine;

public class CheckReadyToReproduce : Node
{
    public CheckReadyToReproduce(BTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var r = (Object)_root.GetData("mate");
        if (r != null)
        {
            _state = NodeState.SUCCESS;
            return _state;
        }
        
        var foodCount = (int)_root.GetData("foodCount");

        _state = foodCount >= GlobalSettings.FoodToRep ? NodeState.SUCCESS : NodeState.FAILURE;
        return _state;
    }
}