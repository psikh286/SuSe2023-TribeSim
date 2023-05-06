using BehaviorTree;
using UnityEngine;

public class CheckWaitingForMate : Node
{
    private Material _mat;
    
    public CheckWaitingForMate(BTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var m = _root.GetData("mate");
        var t = (Transform)_root.GetData("target");
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