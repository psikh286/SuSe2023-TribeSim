using BehaviorTree;
using UnityEngine;

public class CheckWaitingForMate : Node
{
    public CheckWaitingForMate(BTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var m = (Object)_root.GetData("mate");
        var t = (Object)_root.GetData("target");
        if (m == null || t == null)
        {
            _root.ClearData("mate");
            _state = NodeState.FAILURE;
            return _state;
        }
        
        _state = _root.transform != t ? NodeState.FAILURE : NodeState.SUCCESS;

        return _state;
    }
}